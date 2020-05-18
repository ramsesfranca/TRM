using System.ComponentModel.DataAnnotations;
using TPRM.SAP.Web.App_GlobalResources;
using TPRM.SAP.Web.Models;

namespace TPRM.SAP.Web.Areas.Cadastro.Models
{
    public class AlterarEstacionamentoViewModel : BaseViewModel<int>
    {
        [Display(Name = "Nome", ResourceType = typeof(Recurso))]
        [Required(ErrorMessageResourceName = "CampoObrigatorio", ErrorMessageResourceType = typeof(Recurso))]
        [MaxLength(80, ErrorMessageResourceName = "TamanhoMaximo", ErrorMessageResourceType = typeof(Recurso))]
        public string Nome { get; set; }

        [Display(Name = "Endereco", ResourceType = typeof(Recurso))]
        [Required(ErrorMessageResourceName = "CampoObrigatorio", ErrorMessageResourceType = typeof(Recurso))]
        [MaxLength(80, ErrorMessageResourceName = "TamanhoMaximo", ErrorMessageResourceType = typeof(Recurso))]
        public string Endereco { get; set; }

        [Display(Name = "QtdVagas", ResourceType = typeof(Recurso))]
        [Required(ErrorMessageResourceName = "CampoObrigatorio", ErrorMessageResourceType = typeof(Recurso))]
        public string QtdVagas { get; set; }

        [Display(Name = "Cliente", ResourceType = typeof(Recurso))]
        [Required(ErrorMessageResourceName = "CampoObrigatorio", ErrorMessageResourceType = typeof(Recurso))]
        public int ClienteId { get; set; }

        public AlterarClienteViewModel Cliente { get; set; }
    }
}
