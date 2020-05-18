using TPRM.SAP.Modelo;
using TPRM.SAP.Modelo.Entidades.Sistema;

namespace TPRM.SAP.Web.Common.Seguranca
{
    public class ServicoAutenticacao
    {
        public static void CriarSessao(UsuarioSessao usuarioSessao, Usuario entidade)
        {
            if (entidade != null)
            {
                if (usuarioSessao == null)
                {
                    SessaoUsuario.UsuarioAtual = new UsuarioSessao();
                }

                SessaoUsuario.UsuarioAtual.UsuarioId = entidade.Id;
                SessaoUsuario.UsuarioAtual.PerfilId = entidade.PerfilId;
            }
        }
    }
}