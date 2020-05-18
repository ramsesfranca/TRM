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
    public class EstacionamentoController : BaseController
    {
        public IEstacionamentoServico EstacionamentoServico
        {
            get
            {
                return MvcApplication.Container.Resolve<IEstacionamentoServico>();
            }
        }
        public IClienteServico ClienteServico
        {
            get
            {
                return MvcApplication.Container.Resolve<IClienteServico>();
            }
        }

        [SAPAutorizarAttribute("ESTACIONAMENTO", "LISTAR")]
        public ActionResult Index(ListaEstacionamentoViewModel filtro, int? pagina)
        {
            var listaPaginada = this.EstacionamentoServico.SelecionarTodos(Mapper.Map<ListaEstacionamentoViewModel, Estacionamento>(filtro), (pagina ?? 1), 10);

            return View(filtro = new ListaEstacionamentoViewModel
            {
                ListaPaginada = new StaticPagedList<AlterarEstacionamentoViewModel>(Mapper
                    .Map<IEnumerable<Estacionamento>, IEnumerable<AlterarEstacionamentoViewModel>>(listaPaginada), listaPaginada.GetMetaData())
            });
        }

        [SAPAutorizarAttribute("ESTACIONAMENTO", "INSERIR")]
        public ActionResult Inserir()
        {
            ViewBag.ListaCliente = this.ClienteServico.SelecionarTodos();

            return View();
        }

        [HttpPost, SAPAutorizarAttribute("ESTACIONAMENTO", "INSERIR")]
        public ActionResult Inserir(InserirEstacionamentoViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    this.EstacionamentoServico.Inserir(Mapper.Map<InserirEstacionamentoViewModel, Estacionamento>(modelo));
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

        [SAPAutorizarAttribute("ESTACIONAMENTO", "ALTERAR")]
        public ActionResult Alterar(int? id)
        {
            if (id != null)
            {
                var modelo = this.EstacionamentoServico.SelecionarPorId(new Estacionamento { Id = id.Value });

                if (modelo != null)
                {
                    ViewBag.ListaCliente = this.ClienteServico.SelecionarTodos();
                    return View(Mapper.Map<Estacionamento, AlterarEstacionamentoViewModel>(modelo));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, Recurso.RegistroNaoEncontrado);
                }
            }

            return RedirectToAction("Index");
        }

        [HttpPost, SAPAutorizarAttribute("ESTACIONAMENTO", "ALTERAR")]
        public ActionResult Alterar(AlterarEstacionamentoViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    this.EstacionamentoServico.Alterar(Mapper.Map<AlterarEstacionamentoViewModel, Estacionamento>(modelo));
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

        [SAPAutorizarAttribute("ESTACIONAMENTO", "DELETAR")]
        public ActionResult Excluir(int? id)
        {
            if (id != null)
            {
                var entidadeBanco = this.EstacionamentoServico.SelecionarPorId(new Estacionamento { Id = id.Value });

                if (entidadeBanco != null)
                {
                    return PartialView("_ConfirmacaoExclusao", new ConfirmacaoExclusaoViewModel
                    {
                        Id = entidadeBanco.Id,
                        TextoCabecalho = entidadeBanco.Endereco,
                        PostAcaoExcluir = "Excluir",
                        PostControleExcluir = "Estacionamento"
                    });
                }
                else
                {
                    ModelState.AddModelError(string.Empty, Recurso.ExcluidoSucesso);
                }
            }

            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost, SAPAutorizarAttribute("ESTACIONAMENTO", "DELETAR")]
        public ActionResult Excluir(AlterarEstacionamentoViewModel modelo)
        {
            try
            {
                this.EstacionamentoServico.Excluir(Mapper.Map<AlterarEstacionamentoViewModel, Estacionamento>(modelo));
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

        [SAPAutorizarAttribute("ESTACIONAMENTO", "VISUALIZAR")]
        public ActionResult Visualizar(int? id)
        {
            if (id != null)
            {
                var modelo = this.EstacionamentoServico.SelecionarPorId(new Estacionamento { Id = id.Value },
                    new string[] { "Cliente" });

                if (modelo != null)
                {
                    return View(Mapper.Map<Estacionamento, AlterarEstacionamentoViewModel>(modelo));
                }
            }

            ModelState.AddModelError(string.Empty, Recurso.RegistroNaoEncontrado);

            return RedirectToAction("Index");
        }
    }
}
