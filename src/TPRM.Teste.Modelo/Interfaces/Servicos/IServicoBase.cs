using PagedList;
using System.Collections.Generic;
using TPRM.SAP.Modelo.Entidades;
using TPRM.SAP.Modelo.Interfaces.Repositorios;

namespace TPRM.SAP.Modelo.Interfaces.Servicos
{
    public interface IServicoBase<TipoEntidade, in TipoId, ITipoRepositorioBase>
        where TipoEntidade : EntidadeBase<TipoId>
        where ITipoRepositorioBase : IRepositorioBase<TipoEntidade, TipoId>
    {
        void Inserir(TipoEntidade entidade);
        void Alterar(TipoEntidade entidade);
        void Excluir(TipoEntidade entidade);
        TipoEntidade SelecionarPorId(TipoEntidade entidade, params string[] entidadeNavegacao);
        List<TipoEntidade> SelecionarTodos(params string[] entidadeNavegacao);
        IPagedList<TipoEntidade> SelecionarTodos(TipoEntidade entidade, int numeroPagina, int tamanhoPagina, params string[] entidadeNavegacao);
    }
}
