using AutoMapper;
using Microsoft.Practices.Unity;
using PagedList;
using System.Collections.Generic;
using System.Web.Mvc;
using TPRM.SAP.Modelo.Entidades.Gestao;
using TPRM.SAP.Modelo.Interfaces.Servicos.Gestao;
using TPRM.SAP.Web.Areas.Gestao.Models;
using TPRM.SAP.Web.Filters;

namespace TPRM.SAP.Web.Areas.Gestao.Controllers
{
    public class CompetenciaController : Controller
    {
        public ICompetenciaServico CompetenciaServico
        {
            get
            {
                return MvcApplication.Container.Resolve<ICompetenciaServico>();
            }
        }

        [SAPAutorizarAttribute("COMPETENCIA", "LISTAR")]
        public ActionResult Index(ListaCompetenciaViewModel filtro, int? pagina)
        {
            var listaPaginada = this.CompetenciaServico.SelecionarTodos(Mapper.Map<ListaCompetenciaViewModel, Competencia>(filtro), (pagina ?? 1), 10);

            return View(filtro = new ListaCompetenciaViewModel
            {
                ListaPaginada = new StaticPagedList<AlterarCompetenciaViewModel>(Mapper
                    .Map<IEnumerable<Competencia>, IEnumerable<AlterarCompetenciaViewModel>>(listaPaginada), listaPaginada.GetMetaData())
            });
        }

        [SAPAutorizarAttribute("COMPETENCIA", "ALTERAR")]
        public ActionResult Pagar(int? clienteId)
        {
            if (clienteId != null)
            {
                this.CompetenciaServico.Pagar(clienteId.Value);
            }

            return RedirectToAction("Index");
        }

        public ActionResult EnviarEmailCobranca(int? clienteId, int mes, int ano)
        {
            this.CompetenciaServico.EnviarEmailCobranca(clienteId.Value, mes, ano);
            return RedirectToAction("Index");
        }
    }
}
