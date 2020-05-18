using System.ComponentModel.DataAnnotations;
using TPRM.SAP.Modelo.Enums;
using TPRM.SAP.Negocio.Utils;
using TPRM.SAP.Web.App_GlobalResources;
using TPRM.SAP.Web.Models;

namespace TPRM.SAP.Web.Areas.Sistema.Models
{
    public class VisualizarUsuarioViewModel : BaseViewModel<int>
    {
        [Display(Name = "Nome", ResourceType = typeof(Recurso))]
        public string Nome { get; set; }

        [Display(Name = "CPF", ResourceType = typeof(Recurso))]
        public string CPF { get; set; }

        [Display(Name = "Email", ResourceType = typeof(Recurso))]
        public string Email { get; set; }

        [Display(Name = "Status", ResourceType = typeof(Recurso))]
        public Status Status { get; set; }

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

        public AlterarPerfilViewModel Perfil { get; set; }
    }
}
