using System.ComponentModel.DataAnnotations;
using TPRM.SAP.Web.App_GlobalResources;

namespace TPRM.SAP.Web.Areas.Gestao.Models
{
    public class InserirCompetenciaViewModel
    {
        [Display(Name = "Valor", ResourceType = typeof(Recurso))]
        public decimal Valor { get; set; }
    }
}
