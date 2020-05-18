using TPRM.SAP.Modelo.Entidades.Sistema;
using TPRM.SAP.Modelo.Interfaces.Repositorios.Sistema;

namespace TPRM.SAP.Modelo.Interfaces.Servicos.Sistema
{
    public interface IAcaoServico : IServicoBase<Acao, int, IAcaoRepositorio>
    {
    }
}
