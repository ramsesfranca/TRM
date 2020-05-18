using System.Linq;
using TPRM.SAP.Modelo.Entidades.Sistema;
using TPRM.SAP.Modelo.Enums;
using TPRM.SAP.Modelo.Interfaces.Repositorios.Sistema;

namespace TPRM.SAP.Repositorio.Repositorios.Sistema
{
    public class UsuarioRepositorio : RepositorioBase<Usuario, int>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(SAPContexto contexto)
            : base(contexto)
        {
        }

        public override IQueryable<Usuario> SelecionarTodos(Usuario entidade, params string[] entidadeNavegacao)
        {
            var consulta = this.CarregarNavagacao(entidadeNavegacao);

            if (!string.IsNullOrWhiteSpace(entidade.Nome))
            {
                consulta = consulta.Where(x => x.Nome.Trim().ToLower() == entidade.Nome.Trim().ToLower());
            }
            if (!string.IsNullOrWhiteSpace(entidade.CPF))
            {
                consulta = consulta.Where(x => x.CPF.Trim() == entidade.CPF.Trim());
            }
            if (!string.IsNullOrWhiteSpace(entidade.Email))
            {
                consulta = consulta.Where(x => x.Email.Trim().ToLower() == entidade.Email.Trim().ToLower());
            }

            consulta = consulta.Where(x => x.Status != Status.Inativo);

            return consulta.OrderBy(x => x.Nome);
        }
    }
}
