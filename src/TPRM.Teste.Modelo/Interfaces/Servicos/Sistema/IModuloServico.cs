using System.Collections.Generic;
using TPRM.SAP.Modelo.Entidades.Sistema;
using TPRM.SAP.Modelo.Interfaces.Repositorios.Sistema;

namespace TPRM.SAP.Modelo.Interfaces.Servicos.Sistema
{
    public interface IModuloServico : IServicoBase<Modulo, int, IModuloRepositorio>
    {
        List<Modulo> SelecionarTodosModulosAtivos();
        List<Modulo> SelecionarTodosPorPerfil(int perfilId);
    }
}
