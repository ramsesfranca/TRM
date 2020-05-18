using System.Collections.Generic;

namespace TPRM.SAP.Web.Models
{
    public class AcaoViewModel : BaseViewModel<int>
    {
        public string Nome { get; set; }
        public string Texto { get; set; }
        public bool Verificado { get; set; }

        public List<PermissaoViewModel> Permissoes { get; set; }
    }
}
