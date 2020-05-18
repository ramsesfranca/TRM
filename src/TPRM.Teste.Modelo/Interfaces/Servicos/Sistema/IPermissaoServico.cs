using System.Collections.Generic;
using TPRM.SAP.Modelo.Entidades.Sistema;
using TPRM.SAP.Modelo.Interfaces.Repositorios.Sistema;

namespace TPRM.SAP.Modelo.Interfaces.Servicos.Sistema
{
    public interface IPermissaoServico : IServicoBase<Permissao, int, IPermissaoRepositorio>
    {
        List<Permissao> SelecionarTodasPeloPerfilId(int perfilId);
    }
}
