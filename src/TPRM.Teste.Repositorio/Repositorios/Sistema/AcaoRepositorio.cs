using TPRM.SAP.Modelo.Entidades.Sistema;
using TPRM.SAP.Modelo.Interfaces.Repositorios.Sistema;

namespace TPRM.SAP.Repositorio.Repositorios.Sistema
{
    public class AcaoRepositorio : RepositorioBase<Acao, int>, IAcaoRepositorio
    {
        public AcaoRepositorio(SAPContexto contexto)
            : base(contexto)
        {
        }
    }
}
