using System;
using System.Collections.Generic;
using TPRM.SAP.Modelo.Entidades.Cadastro;
using TPRM.SAP.Modelo.Entidades.Gestao;
using TPRM.SAP.Modelo.Enums;

namespace TPRM.SAP.Modelo.Entidades.Sistema
{
    public class Usuario : EntidadeBase<int>
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime? DataHoraLogin { get; set; }
        public Status Status { get; set; }

        public int PerfilId { get; set; }
        public int? CancelaId { get; set; }

        public virtual Perfil Perfil { get; set; }
        public virtual Cancela Cancela { get; set; }
        public virtual ICollection<Movimentacao> Movimentacoes { get; set; }
    }
}
