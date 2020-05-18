using System.Collections.Generic;

namespace TPRM.SAP.Web.Models
{
    public class ModuloViewModel : BaseViewModel<int>
    {
        public string Nome { get; set; }
        public string Area { get; set; }

        public List<FuncionalidadeViewModel> Funcionalidades { get; set; }
    }
}
