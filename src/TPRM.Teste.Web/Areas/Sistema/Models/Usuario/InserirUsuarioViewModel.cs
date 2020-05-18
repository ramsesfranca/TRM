using System.ComponentModel.DataAnnotations;
using TPRM.SAP.Negocio.Utils;
using TPRM.SAP.Web.App_GlobalResources;

namespace TPRM.SAP.Web.Areas.Sistema.Models
{
    public class InserirUsuarioViewModel
    {
        [Display(Name = "Nome", ResourceType = typeof(Recurso))]
        [Required(ErrorMessageResourceName = "CampoObrigatorio", ErrorMessageResourceType = typeof(Recurso))]
        [MaxLength(80, ErrorMessageResourceName = "TamanhoMaximo", ErrorMessageResourceType = typeof(Recurso))]
        public string Nome { get; set; }

        [Display(Name = "CPF", ResourceType = typeof(Recurso))]
        [Required(ErrorMessageResourceName = "CampoObrigatorio", ErrorMessageResourceType = typeof(Recurso))]
        [MaxLength(18, ErrorMessageResourceName = "TamanhoMaximo", ErrorMessageResourceType = typeof(Recurso))]
        public string CPF { get; set; }

        [Display(Name = "Email", ResourceType = typeof(Recurso))]
        [Required(ErrorMessageResourceName = "CampoObrigatorio", ErrorMessageResourceType = typeof(Recurso))]
        [EmailAddress(ErrorMessageResourceName = "EmailInvalido", ErrorMessageResourceType = typeof(Recurso))]
        [MaxLength(50, ErrorMessageResourceName = "TamanhoMaximo", ErrorMessageResourceType = typeof(Recurso))]
        public string Email { get; set; }

        [Display(Name = "Login", ResourceType = typeof(Recurso))]
        [Required(ErrorMessageResourceName = "CampoObrigatorio", ErrorMessageResourceType = typeof(Recurso))]
        [MaxLength(50, ErrorMessageResourceName = "TamanhoMaximo", ErrorMessageResourceType = typeof(Recurso))]
        public string Login { get; set; }

        [Required(ErrorMessageResourceName = "CampoObrigatorio", ErrorMessageResourceType = typeof(Recurso))]
        [MaxLength(50, ErrorMessageResourceName = "TamanhoMaximo", ErrorMessageResourceType = typeof(Recurso))]
        [RegularExpression(RegexUtil.SENHA, ErrorMessageResourceName = "RequisitoSenha", ErrorMessageResourceType = typeof(Recurso))]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Display(Name = "Perfil", ResourceType = typeof(Recurso))]
        [Required(ErrorMessageResourceName = "CampoObrigatorio", ErrorMessageResourceType = typeof(Recurso))]
        public int PerfilId { get; set; }

        [Display(Name = "Cliente", ResourceType = typeof(Recurso))]
        [Required(ErrorMessageResourceName = "CampoObrigatorio", ErrorMessageResourceType = typeof(Recurso))]
        public int? ClienteId { get; set; }

        [Display(Name = "Estacionamento", ResourceType = typeof(Recurso))]
        [Required(ErrorMessageResourceName = "CampoObrigatorio", ErrorMessageResourceType = typeof(Recurso))]
        public int? EstacionamentoId { get; set; }

        [Display(Name = "Cancela", ResourceType = typeof(Recurso))]
        [Required(ErrorMessageResourceName = "CampoObrigatorio", ErrorMessageResourceType = typeof(Recurso))]
        public int? CancelaId { get; set; }
    }
}
