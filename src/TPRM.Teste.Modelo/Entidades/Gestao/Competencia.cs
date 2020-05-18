using TPRM.SAP.Modelo.Entidades.Cadastro;

namespace TPRM.SAP.Modelo.Entidades.Gestao
{
    public class Competencia : EntidadeBase<int>
    {
        public decimal Valor { get; set; }
        public bool Pago { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }

        public int ClienteId { get; set; }
        public int MovimentacaoId { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual Movimentacao Movimentacao { get; set; }
    }
}
