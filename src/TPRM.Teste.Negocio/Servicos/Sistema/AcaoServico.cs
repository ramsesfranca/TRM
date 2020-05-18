using TPRM.SAP.Modelo.Entidades.Sistema;
using TPRM.SAP.Modelo.Interfaces.Repositorios.Sistema;
using TPRM.SAP.Modelo.Interfaces.Servicos.Sistema;

namespace TPRM.SAP.Negocio.Servicos.Sistema
{
    public class AcaoServico : ServicoBase<Acao, int, IAcaoRepositorio>, IAcaoServico
    {
    }
}
