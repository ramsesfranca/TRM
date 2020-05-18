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
    public class CancelaController : BaseController
    {
        public ICancelaServico CancelaServico
        {
            get
            {
                return MvcApplication.Container.Resolve<ICancelaServico>();
            }
        }
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

        [SAPAutorizarAttribute("CANCELA", "LISTAR")]
        public ActionResult Index(ListaCancelaViewModel filtro, int? pagina)
        {
            var listaPaginada = this.CancelaServico.SelecionarTodos(Mapper.Map<ListaCancelaViewModel, Cancela>(filtro), (pagina ?? 1), 10,
                new string[] { "Estacionamento.Cliente" });

            return View(filtro = new ListaCancelaViewModel
            {
                ListaPaginada = new StaticPagedList<AlterarCancelaViewModel>(Mapper
                    .Map<IEnumerable<Cancela>, IEnumerable<AlterarCancelaViewModel>>(listaPaginada), listaPaginada.GetMetaData())
            });
        }

        [SAPAutorizarAttribute("CANCELA", "INSERIR")]
        public ActionResult Inserir()
        {
            ViewBag.ListaCliente = this.ClienteServico.SelecionarTodos();

            return View();
        }

        [HttpPost, SAPAutorizarAttribute("CANCELA", "INSERIR")]
        public ActionResult Inserir(InserirCancelaViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    this.CancelaServico.Inserir(Mapper.Map<InserirCancelaViewModel, Cancela>(modelo));
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

        [SAPAutorizarAttribute("CANCELA", "ALTERAR")]
        public ActionResult Alterar(int? id)
        {
            if (id != null)
            {
                var modelo = this.CancelaServico.SelecionarPorId(new Cancela { Id = id.Value },
                    new string[] { "Estacionamento" });

                if (modelo != null)
                {
                    ViewBag.ListaCliente = this.ClienteServico.SelecionarTodos();

                    if (modelo.Estacionamento != null && modelo.Estacionamento.ClienteId != 0)
                    {
                        ViewBag.ListaEstacionamento = this.EstacionamentoServico.SelecionarPorCliente(modelo.Estacionamento.ClienteId);
                    }

                    return View(Mapper.Map<Cancela, AlterarCancelaViewModel>(modelo));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, Recurso.RegistroNaoEncontrado);
                }
            }

            return RedirectToAction("Index");
        }

        [HttpPost, SAPAutorizarAttribute("CANCELA", "ALTERAR")]
        public ActionResult Alterar(AlterarCancelaViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    this.CancelaServico.Alterar(Mapper.Map<AlterarCancelaViewModel, Cancela>(modelo));
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

        [SAPAutorizarAttribute("CANCELA", "DELETAR")]
        public ActionResult Excluir(int? id)
        {
            if (id != null)
            {
                var entidadeBanco = this.CancelaServico.SelecionarPorId(new Cancela { Id = id.Value });

                if (entidadeBanco != null)
                {
                    return PartialView("_ConfirmacaoExclusao", new ConfirmacaoExclusaoViewModel
                    {
                        Id = entidadeBanco.Id,
                        TextoCabecalho = entidadeBanco.Nome,
                        PostAcaoExcluir = "Excluir",
                        PostControleExcluir = "Cancela"
                    });
                }
                else
                {
                    ModelState.AddModelError(string.Empty, Recurso.ExcluidoSucesso);
                }
            }

            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost, SAPAutorizarAttribute("CANCELA", "DELETAR")]
        public ActionResult Excluir(AlterarCancelaViewModel modelo)
        {
            try
            {
                this.CancelaServico.Excluir(Mapper.Map<AlterarCancelaViewModel, Cancela>(modelo));
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

        [SAPAutorizarAttribute("CANCELA", "VISUALIZAR")]
        public ActionResult Visualizar(int id)
        {
            var modelo = Mapper.Map<Cancela, AlterarCancelaViewModel>(this.CancelaServico.SelecionarPorId(new Cancela { Id = id },
                new string[] { "Estacionamento.Cliente" }));

            if (modelo != null)
            {
                return View(modelo);
            }

            ModelState.AddModelError(string.Empty, Recurso.RegistroNaoEncontrado);

            return RedirectToAction("Index");
        }

        public JsonResult SelecionarEstacionamentoPorCliente(int? clienteId)
        {
            SelectList retorno = null;

            if (clienteId != null)
            {
                retorno = new SelectList(this.EstacionamentoServico.SelecionarPorCliente(clienteId.Value), "Id", "Nome");
            }

            return Json(retorno, JsonRequestBehavior.AllowGet);
        }
    }
}
