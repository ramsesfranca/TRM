using System.ComponentModel.DataAnnotations;
using TPRM.SAP.Negocio.Utils;
using TPRM.SAP.Web.App_GlobalResources;

namespace TPRM.SAP.Web.Models
{
    public class LoginClienteViewModel
    {
        [Display(Name = "CPF", ResourceType = typeof(Recurso))]
        [Required(ErrorMessageResourceName = "CampoObrigatorio", ErrorMessageResourceType = typeof(Recurso))]
        [MaxLength(18, ErrorMessageResourceName = "TamanhoMaximo", ErrorMessageResourceType = typeof(Recurso))]
        public string CPF { get; set; }

        [Display(Name = "Senha", ResourceType = typeof(Recurso))]
        [Required(ErrorMessageResourceName = "CampoObrigatorio", ErrorMessageResourceType = typeof(Recurso))]
        [MaxLength(50, ErrorMessageResourceName = "TamanhoMaximo", ErrorMessageResourceType = typeof(Recurso))]
        [RegularExpression(RegexUtil.SENHA, ErrorMessageResourceName = "RequisitoSenha", ErrorMessageResourceType = typeof(Recurso))]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Display(Name = "Lembrar", ResourceType = typeof(Recurso))]
        public bool Lembrar { get; set; }
    }
}