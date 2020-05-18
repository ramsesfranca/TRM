using System.Linq;
using TPRM.SAP.Modelo.Entidades.Sistema;
using TPRM.SAP.Modelo.Interfaces.Repositorios.Sistema;

namespace TPRM.SAP.Repositorio.Repositorios.Sistema
{
    public class PerfilRepositorio : RepositorioBase<Perfil, int>, IPerfilRepositorio
    {
        public PerfilRepositorio(SAPContexto contexto)
            : base(contexto)
        {
        }

        public override IQueryable<Perfil> SelecionarTodos(Perfil entidade, params string[] entidadeNavegacao)
        {
            return this.CarregarNavagacao(entidadeNavegacao).OrderBy(x => x.Nome);
        }
    }
}
