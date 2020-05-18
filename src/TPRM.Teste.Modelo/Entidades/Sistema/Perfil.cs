using System.Collections.Generic;

namespace TPRM.SAP.Modelo.Entidades.Sistema
{
    public class Perfil : EntidadeBase<int>
    {
        public string Nome { get; set; }

        public virtual ICollection<Permissao> Permissoes { get; set; }
    }
}
