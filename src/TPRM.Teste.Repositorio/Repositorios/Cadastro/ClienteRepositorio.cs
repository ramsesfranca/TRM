using System.Linq;
using TPRM.SAP.Modelo.Entidades.Cadastro;
using TPRM.SAP.Modelo.Interfaces.Repositorios.Cadastro;

namespace TPRM.SAP.Repositorio.Repositorios.Cadastro
{
    public class ClienteRepositorio : RepositorioBase<Cliente, int>, IClienteRepositorio
    {
        public ClienteRepositorio(SAPContexto contexto)
            : base(contexto)
        {
        }

        public override IQueryable<Cliente> SelecionarTodos(Cliente entidade, params string[] entidadeNavegacao)
        {
            return this.CarregarNavagacao(entidadeNavegacao);
        }
    }
}
