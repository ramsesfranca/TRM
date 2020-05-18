using System.Web;
using TPRM.SAP.Modelo;

namespace TPRM.SAP.Web.Common.Seguranca
{
    public static class SessaoUsuario
    {
        public static UsuarioSessao UsuarioAtual
        {
            get
            {
                if (HttpContext.Current.Session["SESSAO_USUARIO"] != null)
                {
                    return (UsuarioSessao)HttpContext.Current.Session["SESSAO_USUARIO"];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (value == null)
                {
                    HttpContext.Current.Session.Remove("SESSAO_USUARIO");
                }
                else
                {
                    HttpContext.Current.Session.Add("SESSAO_USUARIO", value);
                }
            }
        }
    }
}