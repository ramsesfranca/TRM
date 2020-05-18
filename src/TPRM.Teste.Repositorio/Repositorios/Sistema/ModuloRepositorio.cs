using TPRM.SAP.Modelo.Entidades.Sistema;
using TPRM.SAP.Modelo.Interfaces.Repositorios.Sistema;

namespace TPRM.SAP.Repositorio.Repositorios.Sistema
{
    public class ModuloRepositorio : RepositorioBase<Modulo, int>, IModuloRepositorio
    {
        public ModuloRepositorio(SAPContexto contexto)
            : base(contexto)
        {
        }
    }
}
