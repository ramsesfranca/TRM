using Microsoft.Practices.Unity;
using System.Web.Mvc;
using System.Web.Security;
using TPRM.SAP.Modelo.Interfaces.Servicos.Sistema;
using TPRM.SAP.Negocio.Excecoes;
using TPRM.SAP.Web.Models;

namespace TPRM.SAP.Web.Controllers
{
    public class ContaController : BaseController
    {
        public IUsuarioServico UsuarioServico
        {
            get
            {
                return MvcApplication.Container.Resolve<IUsuarioServico>();
            }
        }

        private ActionResult VerificarSeEstaLogado()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Painel", "Home");
            }

            return View();
        }

        private void Deslogar()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.Abandon();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return this.VerificarSeEstaLogado();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (this.UsuarioServico.ValidarLogin(modelo.Login, modelo.Senha))
                    {
                        FormsAuthentication.SetAuthCookie(modelo.Login, modelo.Lembrar);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Login ou Senha inválidos, favor tente novamente.");
                    }
                }
                catch (EntidadeNaoExistenteException ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            return View(modelo);
        }

        [HttpPost]
        public ActionResult Sair()
        {
            this.Deslogar();
            return RedirectToAction("Index", "Home");
        }
    }
}
