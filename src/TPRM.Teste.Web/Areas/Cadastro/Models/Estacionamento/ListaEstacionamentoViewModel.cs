using PagedList;

namespace TPRM.SAP.Web.Areas.Cadastro.Models
{
    public class ListaEstacionamentoViewModel
    {
        public StaticPagedList<AlterarEstacionamentoViewModel> ListaPaginada { get; set; }
    }
}
