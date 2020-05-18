using System;
using System.Linq;
using System.Linq.Expressions;
using TPRM.SAP.Modelo.Entidades;

namespace TPRM.SAP.Modelo.Interfaces.Repositorios
{
    public interface IRepositorioBase<TipoEntidade, TipoId> : IDisposable
        where TipoEntidade : EntidadeBase<TipoId>
    {
        void Inserir(TipoEntidade entidade);
        void Alterar(TipoEntidade entidade);
        void Excluir(TipoEntidade entidade);
        IQueryable<TipoEntidade> SelecionarPorId(TipoId id, params string[] entidadeNavegacao);
        IQueryable<TipoEntidade> SelecionarTodos(params string[] entidadeNavegacao);
        IQueryable<TipoEntidade> SelecionarTodos(TipoEntidade entidade, params string[] entidadeNavegacao);
        IQueryable<TipoEntidade> SelecionarPor(Expression<Func<TipoEntidade, bool>> predicado, params string[] entidadeNavegacao);
    }
}
