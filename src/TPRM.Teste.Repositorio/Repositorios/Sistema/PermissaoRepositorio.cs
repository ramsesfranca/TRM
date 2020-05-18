using TPRM.SAP.Modelo.Entidades.Sistema;
using TPRM.SAP.Modelo.Interfaces.Repositorios.Sistema;

namespace TPRM.SAP.Repositorio.Repositorios.Sistema
{
    public class PermissaoRepositorio : RepositorioBase<Permissao, int>, IPermissaoRepositorio
    {
        public PermissaoRepositorio(SAPContexto contexto)
            : base(contexto)
        {
        }
    }
}
