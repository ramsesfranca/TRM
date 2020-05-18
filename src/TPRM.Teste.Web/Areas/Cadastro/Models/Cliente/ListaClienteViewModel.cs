using PagedList;

namespace TPRM.SAP.Web.Areas.Cadastro.Models
{
    public class ListaClienteViewModel
    {
        public StaticPagedList<AlterarClienteViewModel> ListaPaginada { get; set; }
    }
}
