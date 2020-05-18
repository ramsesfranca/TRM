using System.Linq;
using TPRM.SAP.Modelo.Entidades.Gestao;
using TPRM.SAP.Modelo.Interfaces.Repositorios.Gestao;

namespace TPRM.SAP.Repositorio.Repositorios.Gestao
{
    public class CompetenciaRepositorio : RepositorioBase<Competencia, int>, ICompetenciaRepositorio
    {
        public CompetenciaRepositorio(SAPContexto contexto)
            : base(contexto)
        {
        }

        public override IQueryable<Competencia> SelecionarTodos(Competencia entidade, params string[] entidadeNavegacao)
        {
            return this.CarregarNavagacao(entidadeNavegacao);
        }
    }
}
