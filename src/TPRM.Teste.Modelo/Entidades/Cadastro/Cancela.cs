using System.Collections.Generic;
using TPRM.SAP.Modelo.Entidades.Sistema;

namespace TPRM.SAP.Modelo.Entidades.Cadastro
{
    public class Cancela : EntidadeBase<int>
    {
        public string Nome { get; set; }

        public int EstacionamentoId { get; set; }

        public virtual Estacionamento Estacionamento { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
