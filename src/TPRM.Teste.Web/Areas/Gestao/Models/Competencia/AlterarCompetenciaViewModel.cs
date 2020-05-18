using System.ComponentModel.DataAnnotations;
using TPRM.SAP.Web.App_GlobalResources;
using TPRM.SAP.Web.Models;

namespace TPRM.SAP.Web.Areas.Gestao.Models
{
    public class AlterarCompetenciaViewModel : BaseViewModel<int>
    {
        [Display(Name = "Valor", ResourceType = typeof(Recurso))]
        public decimal Valor { get; set; }

        public bool Pago { get; set; }

        public int Mes { get; set; }

        public int Ano { get; set; }

        public int ClienteId { get; set; }
    }
}
