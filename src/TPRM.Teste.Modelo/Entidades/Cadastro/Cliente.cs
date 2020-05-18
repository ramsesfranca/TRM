using System.Collections.Generic;

namespace TPRM.SAP.Modelo.Entidades.Cadastro
{
    public class Cliente : EntidadeBase<int>
    {
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Estacionamento> Estacionamentos { get; set; }
    }
}
