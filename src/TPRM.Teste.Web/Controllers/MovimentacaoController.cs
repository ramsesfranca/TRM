using AutoMapper;
using Microsoft.Practices.Unity;
using System.Web.Mvc;
using TPRM.SAP.Modelo.Entidades.Gestao;
using TPRM.SAP.Modelo.Interfaces.Servicos.Gestao;
using TPRM.SAP.Negocio.Excecoes;
using TPRM.SAP.Web.Filters;
using TPRM.SAP.Web.Models;

namespace TPRM.SAP.Web.Controllers
{
    [SAPAutorizarAttribute]
    public class MovimentacaoController : BaseController
    {
        public IMovimentacaoServico MovimentacaoServico
        {
            get
            {
                return MvcApplication.Container.Resolve<IMovimentacaoServico>();
            }
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EntraVeiculo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EntraVeiculo(EntradaMovimentacaoViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                ViewData["Message"] = this.MovimentacaoServico.EstadaVeiculo(Mapper.Map<EntradaMovimentacaoViewModel, Movimentacao>(modelo));
            }

            return this.EntraVeiculo();
        }

        public ActionResult PesquisarTicket()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PesquisarTicket(InformarMovimentacaoViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var movimento = this.MovimentacaoServico.SelecionarPorTicket(modelo.Ticket);

                    if (movimento != null)
                    {
                        return RedirectToAction("SaidaVeiculo", new { movimentoId = movimento.Id });
                    }
                }
                catch (EntidadeNaoExistenteException ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            return this.PesquisarTicket();
        }

        public ActionResult SaidaVeiculo(int? movimentoId)
        {
            var valorPagar = this.MovimentacaoServico.CalcularValorPagar(movimentoId.Value);

            return View(new SaidaMovimentacaoViewModel
            {
                Id = movimentoId.Value,
                Valor = valorPagar
            });
        }

        public ActionResult Pagar(int? id)
        {
            this.MovimentacaoServico.SaidaVeiculo(id.Value);

            return RedirectToAction("PesquisarTicket");
        }
    }
}
