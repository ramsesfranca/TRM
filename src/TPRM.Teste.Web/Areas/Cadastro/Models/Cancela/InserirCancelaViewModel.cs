using System.ComponentModel.DataAnnotations;
using TPRM.SAP.Web.App_GlobalResources;

namespace TPRM.SAP.Web.Areas.Cadastro.Models
{
    public class InserirCancelaViewModel
    {
        [Display(Name = "Nome", ResourceType = typeof(Recurso))]
        [Required(ErrorMessageResourceName = "CampoObrigatorio", ErrorMessageResourceType = typeof(Recurso))]
        [MaxLength(80, ErrorMessageResourceName = "TamanhoMaximo", ErrorMessageResourceType = typeof(Recurso))]
        public string Nome { get; set; }

        [Display(Name = "Cliente", ResourceType = typeof(Recurso))]
        [Required(ErrorMessageResourceName = "CampoObrigatorio", ErrorMessageResourceType = typeof(Recurso))]
        public int ClienteId { get; set; }

        [Display(Name = "Estacionamento", ResourceType = typeof(Recurso))]
        [Required(ErrorMessageResourceName = "CampoObrigatorio", ErrorMessageResourceType = typeof(Recurso))]
        public int EstacionamentoId { get; set; }
    }
}
