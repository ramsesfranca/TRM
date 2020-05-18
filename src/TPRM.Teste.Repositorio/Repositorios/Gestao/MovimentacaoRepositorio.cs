using System.Linq;
using TPRM.SAP.Modelo.Entidades.Gestao;
using TPRM.SAP.Modelo.Interfaces.Repositorios.Gestao;

namespace TPRM.SAP.Repositorio.Repositorios.Gestao
{
    public class MovimentacaoRepositorio : RepositorioBase<Movimentacao, int>, IMovimentacaoRepositorio
    {
        public MovimentacaoRepositorio(SAPContexto contexto)
            : base(contexto)
        {
        }

        public override IQueryable<Movimentacao> SelecionarTodos(Movimentacao entidade, params string[] entidadeNavegacao)
        {
            return this.CarregarNavagacao(entidadeNavegacao);
        }
    }
}
