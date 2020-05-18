using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using TPRM.SAP.Modelo.Entidades;
using TPRM.SAP.Modelo.Interfaces.Repositorios;

namespace TPRM.SAP.Repositorio.Repositorios
{
    public abstract class RepositorioBase<TipoEntidade, TipoId> : IRepositorioBase<TipoEntidade, TipoId>
        where TipoEntidade : EntidadeBase<TipoId>
        where TipoId : IEquatable<TipoId>
    {
        public RepositorioBase(SAPContexto contexto)
        {
            if (contexto == null)
            {
                throw new ArgumentNullException("O contexto do repositório não foi instanciado.");
            }

            this._contexto = contexto;
        }

        protected DbSet<TipoEntidade> Entidade
        {
            get
            {
                return _contexto.Set<TipoEntidade>();
            }
        }

        #region Métodos Genérico

        public virtual void Inserir(TipoEntidade entidade)
        {
            this.Entidade.Add(entidade);
            this._contexto.SaveChanges();
        }

        public virtual void Alterar(TipoEntidade entidade)
        {
            this._contexto.Entry(entidade).State = EntityState.Modified;
            this._contexto.SaveChanges();
        }

        public virtual void Excluir(TipoEntidade entidade)
        {
            this.Entidade.Remove(entidade);
            this._contexto.SaveChanges();
        }

        public virtual IQueryable<TipoEntidade> SelecionarPorId(TipoId id, params string[] entidadeNavegacao)
        {
            return this.CarregarNavagacao(entidadeNavegacao).Where(x => x.Id.Equals(id));
        }

        public virtual IQueryable<TipoEntidade> SelecionarTodos(params string[] entidadeNavegacao)
        {
            return this.CarregarNavagacao(entidadeNavegacao);
        }

        public virtual IQueryable<TipoEntidade> SelecionarTodos(TipoEntidade entidade, params string[] entidadeNavegacao)
        {
            throw new NotImplementedException("Este método tem que ser implementando pela classe Repositório que estiver herdando.");
        }

        public virtual IQueryable<TipoEntidade> SelecionarPor(Expression<Func<TipoEntidade, bool>> predicado, params string[] entidadeNavegacao)
        {
            return this.CarregarNavagacao(entidadeNavegacao).Where(predicado);
        }

        protected IQueryable<TipoEntidade> CarregarNavagacao(string[] entidadeNavegacao)
        {
            var consulta = this.Entidade.AsQueryable();

            foreach (var includeProperty in entidadeNavegacao)
            {
                consulta = consulta.Include(includeProperty);
            }

            return consulta;
        }

        #endregion

        #region Métodos Dispose

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this._contexto.Dispose();
                }

                disposed = true;
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        private readonly SAPContexto _contexto;
        private bool disposed = false;
    }
}
