using TPRM.SAP.Modelo.Entidades.Sistema;
using TPRM.SAP.Modelo.Interfaces.Repositorios.Sistema;

namespace TPRM.SAP.Repositorio.Repositorios.Sistema
{
    public class FuncionalidadeRepositorio : RepositorioBase<Funcionalidade, int>, IFuncionalidadeRepositorio
    {
        public FuncionalidadeRepositorio(SAPContexto contexto)
            : base(contexto)
        {
        }
    }
}
