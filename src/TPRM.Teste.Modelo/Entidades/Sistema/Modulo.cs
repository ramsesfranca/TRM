using System.Collections.Generic;
using TPRM.SAP.Modelo.Enums;

namespace TPRM.SAP.Modelo.Entidades.Sistema
{
    public class Modulo : EntidadeBase<int>
    {
        public string Nome { get; set; }
        public string Area { get; set; }
        public int Ordem { get; set; }
        public Status Status { get; set; }

        public virtual ICollection<Funcionalidade> Funcionalidades { get; set; }
    }
}
