using Microsoft.Practices.Unity;
using PagedList;
using System.Collections.Generic;
using System.Linq;
using TPRM.SAP.Modelo.Entidades;
using TPRM.SAP.Modelo.Interfaces.Repositorios;
using TPRM.SAP.Modelo.Interfaces.Servicos;

namespace TPRM.SAP.Negocio.Servicos
{
    public abstract class ServicoBase<TipoEntidade, TipoId, ITipoRepositorioBase> : IServicoBase<TipoEntidade, TipoId, ITipoRepositorioBase>
        where TipoEntidade : EntidadeBase<TipoId>
        where ITipoRepositorioBase : IRepositorioBase<TipoEntidade, TipoId>
    {
        [Dependency]
        public ITipoRepositorioBase RepositorioBase { get; set; }

        public virtual void Inserir(TipoEntidade entidade)
        {
            this.RepositorioBase.Inserir(entidade);
        }

        public virtual void Alterar(TipoEntidade entidade)
        {
            this.RepositorioBase.Alterar(entidade);
        }

        public virtual void Excluir(TipoEntidade entidade)
        {
            this.RepositorioBase.Excluir(this.SelecionarPorId(entidade));
        }

        public virtual TipoEntidade SelecionarPorId(TipoEntidade entidade, params string[] entidadeNavegacao)
        {
            return this.RepositorioBase.SelecionarPorId(entidade.Id, entidadeNavegacao).FirstOrDefault();
        }

        public virtual List<TipoEntidade> SelecionarTodos(params string[] entidadeNavegacao)
        {
            return this.RepositorioBase.SelecionarTodos().ToList();
        }

        public virtual IPagedList<TipoEntidade> SelecionarTodos(TipoEntidade entidade, int numeroPagina, int tamanhoPagina, params string[] entidadeNavegacao)
        {
            return this.RepositorioBase.SelecionarTodos(entidade, entidadeNavegacao)
                .OrderByDescending(x => x.Id)
                .ToPagedList(numeroPagina, tamanhoPagina);
        }
    }
}
