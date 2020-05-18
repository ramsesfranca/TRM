using System.Collections.Generic;

namespace TPRM.SAP.Modelo.Entidades.Cadastro
{
    public class Estacionamento : EntidadeBase<int>
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public int QtdVagas { get; set; }

        public int ClienteId { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<Cancela> Cancelas { get; set; }
    }
}
