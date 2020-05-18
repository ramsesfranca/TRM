using TPRM.SAP.Modelo.Entidades.Gestao;
using TPRM.SAP.Modelo.Interfaces.Repositorios.Gestao;

namespace TPRM.SAP.Modelo.Interfaces.Servicos.Gestao
{
    public interface IMovimentacaoServico : IServicoBase<Movimentacao, int, IMovimentacaoRepositorio>
    {
        string EstadaVeiculo(Movimentacao entidade);
        void SaidaVeiculo(int id);
        Movimentacao SelecionarPorTicket(string ticket);
        decimal CalcularValorPagar(int id);
    }
}
