using PagedList;

namespace TPRM.SAP.Web.Areas.Gestao.Models
{
    public class ListaCompetenciaViewModel
    {
        public StaticPagedList<AlterarCompetenciaViewModel> ListaPaginada { get; set; }
    }
}
