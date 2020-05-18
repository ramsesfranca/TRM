using PagedList;

namespace TPRM.SAP.Web.Areas.Sistema.Models
{
    public class ListaPerfilViewModel
    {
        public StaticPagedList<AlterarPerfilViewModel> ListaPaginada { get; set; }
    }
}
