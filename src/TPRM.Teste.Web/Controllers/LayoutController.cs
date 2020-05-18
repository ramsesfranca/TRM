using AutoMapper;
using Microsoft.Practices.Unity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TPRM.SAP.Modelo.Entidades.Sistema;
using TPRM.SAP.Modelo.Interfaces.Servicos.Sistema;
using TPRM.SAP.Web;
using TPRM.SAP.Web.Common.Seguranca;
using TPRM.SAP.Web.Models;

namespace Teste.Controllers
{
    public class LayoutController : Controller
    {
        public IModuloServico ModuloServico
        {
            get
            {
                return MvcApplication.Container.Resolve<IModuloServico>();
            }
        }
        public IUsuarioServico UsuarioServico
        {
            get
            {
                return MvcApplication.Container.Resolve<IUsuarioServico>();
            }
        }

        public ActionResult Menu()
        {
            var modelo = Mapper.Map<List<Modulo>, List<ModuloViewModel>>(this.ModuloServico
                .SelecionarTodosPorPerfil(SessaoUsuario.UsuarioAtual.PerfilId));

            return PartialView("_Menu", modelo);
        }

        public ActionResult Login()
        {
            var nome = string.Empty;

            if (SessaoUsuario.UsuarioAtual != null)
            {
                nome = this.UsuarioServico.SelecionarPorId(new Usuario { Id = SessaoUsuario.UsuarioAtual.UsuarioId }).Nome;
            }
            else
            {
                nome = this.UsuarioServico.SelecionarPeloNome(User.Identity.Name).Nome;
            }

            var nomeArry = nome.Split(' ');

            var modelo = new LayoutViewModel
            {
                Nome = nomeArry.Count() >= 2 ? string.Format("{0} {1}", nomeArry.First(), nomeArry.Last()) : nome
            };

            return PartialView("_Login", modelo);
        }
    }
}
