using AutoMapper;
using Microsoft.Practices.Unity;
using PagedList;
using System.Collections.Generic;
using System.Web.Mvc;
using TPRM.SAP.Modelo.Entidades.Sistema;
using TPRM.SAP.Modelo.Interfaces.Servicos.Cadastro;
using TPRM.SAP.Modelo.Interfaces.Servicos.Sistema;
using TPRM.SAP.Negocio.Excecoes;
using TPRM.SAP.Web.App_GlobalResources;
using TPRM.SAP.Web.Areas.Sistema.Models;
using TPRM.SAP.Web.Controllers;
using TPRM.SAP.Web.Filters;

namespace TPRM.SAP.Web.Areas.Sistema.Controllers
{
    [SAPAutorizarAttribute]
    public class UsuarioController : BaseController
    {
        public IUsuarioServico UsuarioServico
        {
            get
            {
                return MvcApplication.Container.Resolve<IUsuarioServico>();
            }
        }
        public IPerfilServico PerfilServico
        {
            get
            {
                return MvcApplication.Container.Resolve<IPerfilServico>();
            }
        }
        public IClienteServico ClienteServico
        {
            get
            {
                return MvcApplication.Container.Resolve<IClienteServico>();
            }
        }
        public IEstacionamentoServico EstacionamentoServico
        {
            get
            {
                return MvcApplication.Container.Resolve<IEstacionamentoServico>();
            }
        }
        public ICancelaServico CancelaServico
        {
            get
            {
                return MvcApplication.Container.Resolve<ICancelaServico>();
            }
        }

        private void ValidarCampos(InserirUsuarioViewModel modelo)
        {
            if (modelo.PerfilId == 1 || modelo.PerfilId == 2)
            {
                ModelState.Remove("ClienteId");
                ModelState.Remove("EstacionamentoId");
                ModelState.Remove("CancelaId");
            }
        }

        private void SelecionarListaAuxiliares()
        {
            ViewBag.ListaPerfil = this.PerfilServico.SelecionarTodos();
            ViewBag.ListaCliente = this.ClienteServico.SelecionarTodos();
        }

        [SAPAutorizarAttribute("USUARIO", "LISTAR")]
        public ActionResult Index(ListaUsuarioViewModel filtro, int? pagina)
        {
            var listaPaginada = this.UsuarioServico.SelecionarTodos(Mapper.Map<ListaUsuarioViewModel, Usuario>(filtro), (pagina ?? 1), 10,
                new string[] { "Perfil", "Cancela.Estacionamento" });

            ViewBag.ListaPerfil = this.PerfilServico.SelecionarTodos();

            return View(filtro = new ListaUsuarioViewModel
            {
                ListaPaginada = new StaticPagedList<AlterarUsuarioViewModel>(Mapper
                    .Map<IEnumerable<Usuario>, IEnumerable<AlterarUsuarioViewModel>>(listaPaginada), listaPaginada.GetMetaData())
            });
        }

        [SAPAutorizarAttribute("USUARIO", "INSERIR")]
        public ActionResult Inserir()
        {
            this.SelecionarListaAuxiliares();

            return View();
        }

        [HttpPost, SAPAutorizarAttribute("USUARIO", "INSERIR")]
        public ActionResult Inserir(InserirUsuarioViewModel modelo)
        {
            this.ValidarCampos(modelo);

            if (ModelState.IsValid)
            {
                this.UsuarioServico.Inserir(Mapper.Map<InserirUsuarioViewModel, Usuario>(modelo));
                ModelState.AddModelError(string.Empty, Recurso.CadastradoSucesso);
                return RedirectToAction("Index");
            }

            return this.Inserir();
        }

        [SAPAutorizarAttribute("USUARIO", "ALTERAR")]
        public ActionResult Alterar(int id)
        {
            var modelo = this.UsuarioServico.SelecionarPorId(new Usuario { Id = id }, new string[] { "Cancela.Estacionamento" });

            if (modelo != null)
            {
                this.SelecionarListaAuxiliares();

                if (modelo.Cancela != null && modelo.Cancela.Estacionamento.ClienteId != 0)
                {
                    ViewBag.ListaEstacionamento = this.EstacionamentoServico.SelecionarPorCliente(modelo.Cancela.Estacionamento.ClienteId);
                }
                if (modelo.Cancela != null && modelo.Cancela.EstacionamentoId != 0)
                {
                    ViewBag.ListaCancela = this.CancelaServico.SelecionarPorEstacionamento(modelo.Cancela.EstacionamentoId);
                }

                return View(Mapper.Map<Usuario, AlterarUsuarioViewModel>(modelo));
            }
            else
            {
                ModelState.AddModelError(string.Empty, Recurso.RegistroNaoEncontrado);
            }

            return RedirectToAction("Index");
        }

        [HttpPost, SAPAutorizarAttribute("USUARIO", "ALTERAR")]
        public ActionResult Alterar(AlterarUsuarioViewModel modelo)
        {
            if (string.IsNullOrWhiteSpace(modelo.Senha))
            {
                ModelState.Remove("Senha");
            }

            this.ValidarCampos(modelo);

            if (ModelState.IsValid)
            {
                try
                {
                    this.UsuarioServico.Alterar(Mapper.Map<AlterarUsuarioViewModel, Usuario>(modelo));
                    ModelState.AddModelError(string.Empty, Recurso.AlteradoSucesso);
                    return RedirectToAction("Index");
                }
                catch (EntidadeNaoExistenteException ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            return this.Alterar(modelo.Id);
        }

        [SAPAutorizarAttribute("USUARIO", "DELETAR")]
        public ActionResult Excluir(AlterarUsuarioViewModel modelo)
        {
            try
            {
                this.UsuarioServico.Excluir(Mapper.Map<AlterarUsuarioViewModel, Usuario>(modelo));
                ModelState.AddModelError(string.Empty, Recurso.ExcluidoSucesso);
            }
            catch (EntidadeNaoExistenteException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return RedirectToAction("Index");
        }

        [SAPAutorizarAttribute("USUARIO", "VISUALIZAR")]
        public ActionResult Visualizar(int id)
        {
            var modelo = Mapper.Map<Usuario, VisualizarUsuarioViewModel>(this.UsuarioServico.SelecionarPorId(new Usuario { Id = id },
                new string[] { "Perfil" }));

            if (modelo != null)
            {
                return View(modelo);
            }

            ModelState.AddModelError(string.Empty, Recurso.RegistroNaoEncontrado);

            return RedirectToAction("Index");
        }

        public JsonResult SelecionarCancelaPorEstacionamento(int? estacionamentoId)
        {
            SelectList retorno = null;

            if (estacionamentoId != null)
            {
                retorno = new SelectList(this.CancelaServico.SelecionarPorEstacionamento(estacionamentoId.Value), "Id", "Nome");
            }

            return Json(retorno, JsonRequestBehavior.AllowGet);
        }
    }
}
