using TPRM.SAP.Modelo.Entidades.Sistema;
using TPRM.SAP.Modelo.Interfaces.Repositorios.Sistema;

namespace TPRM.SAP.Modelo.Interfaces.Servicos.Sistema
{
    public interface IUsuarioServico : IServicoBase<Usuario, int, IUsuarioRepositorio>
    {
        bool ValidarLogin(string login, string senha);
        Usuario SelecionarPeloNome(string login);
    }
}
