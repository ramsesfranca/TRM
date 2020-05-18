using System.Collections.Generic;

namespace TPRM.SAP.Modelo.Entidades.Sistema
{
    public class Acao : EntidadeBase<int>
    {
        public string Nome { get; set; }
        public string Texto { get; set; }

        public virtual ICollection<Permissao> Permissoes { get; set; }
    }
}
