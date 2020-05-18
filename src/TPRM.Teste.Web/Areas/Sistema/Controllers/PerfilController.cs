using AutoMapper;
using Microsoft.Practices.Unity;
using PagedList;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TPRM.SAP.Modelo.Entidades.Sistema;
using TPRM.SAP.Modelo.Interfaces.Servicos.Sistema;
using TPRM.SAP.Web.Areas.Sistema.Models;
using TPRM.SAP.Web.Controllers;
using TPRM.SAP.Web.Filters;
using TPRM.SAP.Web.Models;

namespace TPRM.SAP.Web.Areas.Sistema.Controllers
{
    [SAPAutorizarAttribute]
    public class PerfilController : BaseController
    {
        public IPerfilServico PerfilServico
        {
            get
            {
                return MvcApplication.Container.Resolve<IPerfilServico>();
            }
        }
        public IModuloServico ModuloServico
        {
            get
            {
                return MvcApplication.Container.Resolve<IModuloServico>();
            }
        }

        private void RecuperarPermissoes(AlterarPerfilViewModel modelo)
        {
            if (modelo.Modulos != null && modelo.Modulos.Count > 0)
            {
                modelo.Permissoes = new List<PermissaoViewModel>();

                foreach (var modulo in modelo.Modulos)
                {
                    foreach (var funcionalidade in modulo.Funcionalidades.Where(x => x.Acoes.Any(y => y.Verificado == true)).ToList())
                    {
                        foreach (var acao in funcionalidade.Acoes.Where(x => x.Verificado == true).ToList())
                        {
                            modelo.Permissoes.Add(new PermissaoViewModel { AcaoId = acao.Id, FuncionalidadeId = funcionalidade.Id });
                        }
                    }
                }
            }
        }

        [SAPAutorizarAttribute("PERFIL", "LISTAR")]
        public ActionResult Index(ListaPerfilViewModel filtro, int? pagina)
        {
            var listaPaginada = this.PerfilServico.SelecionarTodos(Mapper.Map<ListaPerfilViewModel, Perfil>(filtro), (pagina ?? 1), 10);

            return View(new ListaPerfilViewModel
            {
                ListaPaginada = new StaticPagedList<AlterarPerfilViewModel>(Mapper
                    .Map<IEnumerable<Perfil>, IEnumerable<AlterarPerfilViewModel>>(listaPaginada), listaPaginada.GetMetaData())
            });
        }

        [SAPAutorizarAttribute("PERFIL", "INSERIR")]
        public ActionResult Inserir()
        {
            var modelo = new AlterarPerfilViewModel
            {
                Modulos = Mapper.Map<List<Modulo>, List<ModuloViewModel>>(this.ModuloServico.SelecionarTodosModulosAtivos())
            };

            return View(modelo);
        }

        [HttpPost, SAPAutorizarAttribute("PERFIL", "INSERIR")]
        public ActionResult Inserir(AlterarPerfilViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                this.RecuperarPermissoes(modelo);
                this.PerfilServico.Inserir(Mapper.Map<AlterarPerfilViewModel, Perfil>(modelo));
                return RedirectToAction("Index");
            }

            return this.Inserir();
        }

        [SAPAutorizarAttribute("PERFIL", "ALTERAR")]
        public ActionResult Alterar(int id)
        {
            var perfilBanco = this.PerfilServico.SelecionarPorId(new Perfil { Id = id }, new string[] { "Permissoes" });
            var listaModulo = this.ModuloServico.SelecionarTodosModulosAtivos();

            var listaModeloModulo = new List<ModuloViewModel>();

            foreach (var modulo in listaModulo)
            {
                List<FuncionalidadeViewModel> listaFuncionalidade = new List<FuncionalidadeViewModel>();

                foreach (var funcionalidade in modulo.Funcionalidades)
                {
                    var listaAcao = new List<AcaoViewModel>();

                    foreach (var acao in funcionalidade.Acoes)
                    {
                        if (perfilBanco.Permissoes.Any(x => x.FuncionalidadeId == funcionalidade.Id && x.AcaoId == acao.Id))
                        {
                            listaAcao.Add(new AcaoViewModel { Id = acao.Id, Nome = acao.Nome, Texto = acao.Texto, Verificado = true });
                        }
                        else
                        {
                            listaAcao.Add(new AcaoViewModel { Id = acao.Id, Nome = acao.Nome, Texto = acao.Texto });
                        }
                    }

                    listaFuncionalidade.Add(new FuncionalidadeViewModel
                    {
                        Id = funcionalidade.Id,
                        Nome = funcionalidade.Nome,
                        Texto = funcionalidade.Texto,
                        Acoes = listaAcao,
                        SelecionarTodos = listaAcao.Where(x => x.Verificado == true).ToList().Count == funcionalidade.Acoes.Count ? true : false
                    });
                }

                listaModeloModulo.Add(new ModuloViewModel { Id = modulo.Id, Nome = modulo.Nome, Funcionalidades = listaFuncionalidade });
            }

            var modelo = Mapper.Map<Perfil, AlterarPerfilViewModel>(perfilBanco);

            modelo.Modulos = listaModeloModulo;

            return View(modelo);
        }

        [HttpPost, SAPAutorizarAttribute("PERFIL", "ALTERAR")]
        public ActionResult Alterar(AlterarPerfilViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                this.RecuperarPermissoes(modelo);
                this.PerfilServico.Alterar(Mapper.Map<AlterarPerfilViewModel, Perfil>(modelo));

                return RedirectToAction("Index");
            }

            return this.Alterar(modelo.Id);
        }
    }
}
