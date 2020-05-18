using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TPRM.SAP.Web.App_GlobalResources;
using TPRM.SAP.Web.Models;

namespace TPRM.SAP.Web.Areas.Sistema.Models
{
    public class AlterarPerfilViewModel : BaseViewModel<int>
    {
        [Display(Name = "Nome", ResourceType = typeof(Recurso))]
        [Required(ErrorMessageResourceName = "CampoObrigatorio", ErrorMessageResourceType = typeof(Recurso))]
        [MaxLength(80, ErrorMessageResourceName = "TamanhoMaximo", ErrorMessageResourceType = typeof(Recurso))]
        public string Nome { get; set; }
        
        public List<PermissaoViewModel> Permissoes { get; set; }

        [Display(Name = "Permissoes", ResourceType = typeof(Recurso))]
        public List<ModuloViewModel> Modulos { get; set; }
    }
}
