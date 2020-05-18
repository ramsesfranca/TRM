using System.Collections.Generic;

namespace TPRM.SAP.Web.Models
{
    public class FuncionalidadeViewModel : BaseViewModel<int>
    {
        public string Nome { get; set; }
        public string Texto { get; set; }
        public string Controlador { get; set; }
        public string Acao { get; set; }
        public int Ordem { get; set; }
        public bool SelecionarTodos { get; set; }

        public int ModuloId { get; set; }

        public ModuloViewModel Modulo { get; set; }
        public List<PermissaoViewModel> Permissoes { get; set; }
        public List<AcaoViewModel> Acoes { get; set; }
    }
}
