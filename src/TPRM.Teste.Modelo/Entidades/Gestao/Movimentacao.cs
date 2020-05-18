using System;
using TPRM.SAP.Modelo.Entidades.Cadastro;
using TPRM.SAP.Modelo.Entidades.Sistema;
using TPRM.SAP.Modelo.Enums;

namespace TPRM.SAP.Modelo.Entidades.Gestao
{
    public class Movimentacao : EntidadeBase<int>
    {
        public string PlacaCarro { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Ticket { get; set; }
        public DateTime DataHoraEntrada { get; set; }
        public DateTime? DataHoraSaida { get; set; }
        public TipoMovimentacao TipoMovimentacao { get; set; }

        public int UsuarioId { get; set; }
        public int ClienteId { get; set; }

        public virtual Usuario Operador { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
