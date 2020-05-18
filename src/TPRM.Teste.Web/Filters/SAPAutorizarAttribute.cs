using Microsoft.Practices.Unity;
using System;
using System.Linq;
using System.Web.Mvc;
using TPRM.SAP.Modelo.Interfaces.Servicos.Sistema;
using TPRM.SAP.Web.Common.Seguranca;

namespace TPRM.SAP.Web.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true)]
    public class SAPAutorizarAttributeAttribute : AuthorizeAttribute
    {
        public IUsuarioServico UsuarioServico
        {
            get
            {
                return MvcApplication.Container.Resolve<IUsuarioServico>();
            }
        }
        public IPermissaoServico PermissaoServico
        {
            get
            {
                return MvcApplication.Container.Resolve<IPermissaoServico>();
            }
        }

        public SAPAutorizarAttributeAttribute()
        {
        }

        public SAPAutorizarAttributeAttribute(string funcionalidade, string permissao)
        {
            _funcionalidade = funcionalidade;
            _acao = permissao;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
            else
            {
                var entidadeBanco = this.UsuarioServico.SelecionarPeloNome(filterContext.HttpContext.User.Identity.Name);

                ServicoAutenticacao.CriarSessao(SessaoUsuario.UsuarioAtual, entidadeBanco);

                if (!string.IsNullOrEmpty(_funcionalidade) && !string.IsNullOrEmpty(_acao))
                {
                    var listaPermissoes = this.PermissaoServico.SelecionarTodasPeloPerfilId(SessaoUsuario.UsuarioAtual.PerfilId);

                    if (!listaPermissoes.Any(x => x.Funcionalidade.Controlador.ToUpper().Equals(_funcionalidade.ToUpper()) &&
                        x.Acao.Nome.ToUpper().Equals(_acao.ToUpper())))
                    {
                        filterContext.Result = new RedirectResult("~/Erro/AcessoNaoAutorizado");
                    }

                    SessaoUsuario.UsuarioAtual.ListaPermissao = listaPermissoes;
                }
            }

            base.OnAuthorization(filterContext);
        }

        private readonly string _funcionalidade;
        private readonly string _acao;
    }
}
