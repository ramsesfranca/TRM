using System.ComponentModel.DataAnnotations;
using TPRM.SAP.Web.App_GlobalResources;

namespace TPRM.SAP.Web.Areas.Cadastro.Models
{
    public class InserirClienteViewModel
    {
        [Display(Name = "Nome", ResourceType = typeof(Recurso))]
        [Required(ErrorMessageResourceName = "CampoObrigatorio", ErrorMessageResourceType = typeof(Recurso))]
        [MaxLength(80, ErrorMessageResourceName = "TamanhoMaximo", ErrorMessageResourceType = typeof(Recurso))]
        public string Nome { get; set; }

        [Display(Name = "CNPJ", ResourceType = typeof(Recurso))]
        [Required(ErrorMessageResourceName = "CampoObrigatorio", ErrorMessageResourceType = typeof(Recurso))]
        [MaxLength(18, ErrorMessageResourceName = "TamanhoMaximo", ErrorMessageResourceType = typeof(Recurso))]
        public string CNPJ { get; set; }

        [Display(Name = "Email", ResourceType = typeof(Recurso))]
        [Required(ErrorMessageResourceName = "CampoObrigatorio", ErrorMessageResourceType = typeof(Recurso))]
        [EmailAddress(ErrorMessageResourceName = "EmailInvalido", ErrorMessageResourceType = typeof(Recurso))]
        [MaxLength(50, ErrorMessageResourceName = "TamanhoMaximo", ErrorMessageResourceType = typeof(Recurso))]
        public string Email { get; set; }
    }
}
