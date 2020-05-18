using System.Linq;
using TPRM.SAP.Modelo.Entidades.Cadastro;
using TPRM.SAP.Modelo.Interfaces.Repositorios.Cadastro;

namespace TPRM.SAP.Repositorio.Repositorios.Cadastro
{
    public class CancelaRepositorio : RepositorioBase<Cancela, int>, ICancelaRepositorio
    {
        public CancelaRepositorio(SAPContexto contexto)
            : base(contexto)
        {
        }

        public override IQueryable<Cancela> SelecionarTodos(Cancela entidade, params string[] entidadeNavegacao)
        {
            return this.CarregarNavagacao(entidadeNavegacao);
        }
    }
}
