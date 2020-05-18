using PagedList;

namespace TPRM.SAP.Web.Areas.Cadastro.Models
{
    public class ListaCancelaViewModel
    {
        public StaticPagedList<AlterarCancelaViewModel> ListaPaginada { get; set; }
    }
}
