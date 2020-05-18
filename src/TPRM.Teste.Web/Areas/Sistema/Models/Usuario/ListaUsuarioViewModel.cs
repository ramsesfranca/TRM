using PagedList;

namespace TPRM.SAP.Web.Areas.Sistema.Models
{
    public class ListaUsuarioViewModel
    {
        public StaticPagedList<AlterarUsuarioViewModel> ListaPaginada { get; set; }
    }
}
