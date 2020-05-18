using System.ComponentModel.DataAnnotations;
using TPRM.SAP.Modelo.Enums;
using TPRM.SAP.Web.App_GlobalResources;
using TPRM.SAP.Web.Common.Seguranca;

namespace TPRM.SAP.Web.Models
{
    public class EntradaMovimentacaoViewModel
    {
        public int UsuarioId { get; private set; } = SessaoUsuario.UsuarioAtual.UsuarioId;
        public TipoMovimentacao TipoMovimentacao { get; private set; } = TipoMovimentacao.Entrada;

        [Display(Name = "PlacaCarro", ResourceType = typeof(Recurso))]
        [Required(ErrorMessageResourceName = "CampoObrigatorio", ErrorMessageResourceType = typeof(Recurso))]
        [MaxLength(80, ErrorMessageResourceName = "TamanhoMaximo", ErrorMessageResourceType = typeof(Recurso))]
        public string PlacaCarro { get; set; }

        [Display(Name = "Marca", ResourceType = typeof(Recurso))]
        [Required(ErrorMessageResourceName = "CampoObrigatorio", ErrorMessageResourceType = typeof(Recurso))]
        [MaxLength(80, ErrorMessageResourceName = "TamanhoMaximo", ErrorMessageResourceType = typeof(Recurso))]
        public string Marca { get; set; }

        [Display(Name = "Modelo", ResourceType = typeof(Recurso))]
        [Required(ErrorMessageResourceName = "CampoObrigatorio", ErrorMessageResourceType = typeof(Recurso))]
        [MaxLength(80, ErrorMessageResourceName = "TamanhoMaximo", ErrorMessageResourceType = typeof(Recurso))]
        public string ModeloCarro { get; set; }
    }
}
