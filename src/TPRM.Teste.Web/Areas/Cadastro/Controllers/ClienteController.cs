using AutoMapper;
using Microsoft.Practices.Unity;
using PagedList;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Web.Mvc;
using TPRM.SAP.Modelo.Entidades.Cadastro;
using TPRM.SAP.Modelo.Interfaces.Servicos.Cadastro;
using TPRM.SAP.Negocio.Excecoes;
using TPRM.SAP.Web.App_GlobalResources;
using TPRM.SAP.Web.Areas.Cadastro.Models;
using TPRM.SAP.Web.Controllers;
using TPRM.SAP.Web.Filters;
using TPRM.SAP.Web.Models;

namespace TPRM.SAP.Web.Areas.Cadastro.Controllers
{
    [SAPAutorizarAttribute]
    public class ClienteController : BaseController
    {
        public IClienteServico ClienteServico
        {
            get
            {
                return MvcApplication.Container.Resolve<IClienteServico>();
            }
        }

        [SAPAutorizarAttribute("CLIENTE", "LISTAR")]
        public ActionResult Index(ListaClienteViewModel filtro, int? pagina)
        {
            var listaPaginada = this.ClienteServico.SelecionarTodos(Mapper.Map<ListaClienteViewModel, Cliente>(filtro), (pagina ?? 1), 10);

            return View(filtro = new ListaClienteViewModel
            {
                ListaPaginada = new StaticPagedList<AlterarClienteViewModel>(Mapper
                    .Map<IEnumerable<Cliente>, IEnumerable<AlterarClienteViewModel>>(listaPaginada), listaPaginada.GetMetaData())
            });
        }

        [SAPAutorizarAttribute("CLIENTE", "INSERIR")]
        public ActionResult Inserir()
        {
            return View();
        }

        [HttpPost, SAPAutorizarAttribute("CLIENTE", "INSERIR")]
        public ActionResult Inserir(InserirClienteViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    this.ClienteServico.Inserir(Mapper.Map<InserirClienteViewModel, Cliente>(modelo));
                    ModelState.AddModelError(string.Empty, Recurso.CadastradoSucesso);
                    return RedirectToAction("Index");
                }
                catch (EntidadeNaoExistenteException ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            return this.Inserir();
        }

        [SAPAutorizarAttribute("CLIENTE", "ALTERAR")]
        public ActionResult Alterar(int id)
        {
            var modelo = Mapper.Map<Cliente, AlterarClienteViewModel>(this.ClienteServico.SelecionarPorId(new Cliente { Id = id }));

            if (modelo != null)
            {
                return View(modelo);
            }
            else
            {
                ModelState.AddModelError(string.Empty, Recurso.RegistroNaoEncontrado);
            }

            return RedirectToAction("Index");
        }

        [HttpPost, SAPAutorizarAttribute("CLIENTE", "ALTERAR")]
        public ActionResult Alterar(AlterarClienteViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    this.ClienteServico.Alterar(Mapper.Map<AlterarClienteViewModel, Cliente>(modelo));
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

        [SAPAutorizarAttribute("CLIENTE", "DELETAR")]
        public ActionResult Excluir(int? id)
        {
            if (id != null)
            {
                var entidadeBanco = this.ClienteServico.SelecionarPorId(new Cliente { Id = id.Value });

                if (entidadeBanco != null)
                {
                    return PartialView("_ConfirmacaoExclusao", new ConfirmacaoExclusaoViewModel
                    {
                        Id = entidadeBanco.Id,
                        TextoCabecalho = entidadeBanco.Nome,
                        PostAcaoExcluir = "Excluir",
                        PostControleExcluir = "Cliente"
                    });
                }
                else
                {
                    ModelState.AddModelError(string.Empty, Recurso.ExcluidoSucesso);
                }
            }

            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost, SAPAutorizarAttribute("CLIENTE", "DELETAR")]
        public ActionResult Excluir(AlterarClienteViewModel modelo)
        {
            try
            {
                this.ClienteServico.Excluir(Mapper.Map<AlterarClienteViewModel, Cliente>(modelo));
                ModelState.AddModelError(string.Empty, Recurso.ExcluidoSucesso);
            }
            catch (EntidadeNaoExistenteException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError(string.Empty, Recurso.MPAlertaNaoPodeDeletar);
            }

            return RedirectToAction("Index");
        }

        [SAPAutorizarAttribute("CLIENTE", "VISUALIZAR")]
        public ActionResult Visualizar(int id)
        {
            var modelo = Mapper.Map<Cliente, AlterarClienteViewModel>(this.ClienteServico.SelecionarPorId(new Cliente { Id = id }));

            if (modelo != null)
            {
                return View(modelo);
            }

            ModelState.AddModelError(string.Empty, Recurso.RegistroNaoEncontrado);

            return RedirectToAction("Index");
        }
    }
}
