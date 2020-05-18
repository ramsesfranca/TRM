using System.Linq;
using TPRM.SAP.Modelo.Entidades.Cadastro;
using TPRM.SAP.Modelo.Interfaces.Repositorios.Cadastro;

namespace TPRM.SAP.Repositorio.Repositorios.Cadastro
{
    public class EstacionamentoRepositorio : RepositorioBase<Estacionamento, int>, IEstacionamentoRepositorio
    {
        public EstacionamentoRepositorio(SAPContexto contexto)
            : base(contexto)
        {
        }

        public override IQueryable<Estacionamento> SelecionarTodos(Estacionamento entidade, params string[] entidadeNavegacao)
        {
            return this.CarregarNavagacao(entidadeNavegacao);
        }
    }
}
