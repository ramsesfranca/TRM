using System.ComponentModel.DataAnnotations;
using TPRM.SAP.Web.App_GlobalResources;

namespace TPRM.SAP.Web.Models
{
    public class InformarMovimentacaoViewModel
    {
        [Display(Name = "Ticket", ResourceType = typeof(Recurso))]
        [Required(ErrorMessageResourceName = "CampoObrigatorio", ErrorMessageResourceType = typeof(Recurso))]
        [MaxLength(80, ErrorMessageResourceName = "TamanhoMaximo", ErrorMessageResourceType = typeof(Recurso))]
        public string Ticket { get; set; }
    }
}