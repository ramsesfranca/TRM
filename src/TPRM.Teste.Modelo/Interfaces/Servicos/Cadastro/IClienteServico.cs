using TPRM.SAP.Modelo.Entidades.Cadastro;
using TPRM.SAP.Modelo.Interfaces.Repositorios.Cadastro;

namespace TPRM.SAP.Modelo.Interfaces.Servicos.Cadastro
{
    public interface IClienteServico : IServicoBase<Cliente, int, IClienteRepositorio>
    {
    }
}
