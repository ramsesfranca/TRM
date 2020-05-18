using Microsoft.Practices.Unity;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using TPRM.SAP.Modelo.Entidades.Sistema;
using TPRM.SAP.Modelo.Interfaces.Repositorios.Sistema;
using TPRM.SAP.Modelo.Interfaces.Servicos.Sistema;

namespace TPRM.SAP.Negocio.Servicos.Sistema
{
    public class PerfilServico : ServicoBase<Perfil, int, IPerfilRepositorio>, IPerfilServico
    {
        [Dependency]
        public IFuncionalidadeServico FuncionalidadeServico { private get; set; }
        [Dependency]
        public IAcaoServico AcaoServico { private get; set; }
        [Dependency]
        public IPermissaoServico PermissaoServico { private get; set; }

        private List<Permissao> RecuperarAcaoListar(Perfil entidade)
        {
            var listaPermissoesAgrupadasPorFcunionalidade = entidade.Permissoes.GroupBy(x => x.FuncionalidadeId)
                .Select(x => x.ToList()).ToList();

            foreach (var permissao in listaPermissoesAgrupadasPorFcunionalidade.ToList())
            {
                if (permissao.Count > 0)
                {
                    var funcionalidade = this.FuncionalidadeServico.SelecionarPorId(new Funcionalidade { Id = permissao.First().FuncionalidadeId },
                        new string[] { "Acoes" });
                    var acao = funcionalidade.Acoes.Where(x => x.Nome.Equals("Listar")).FirstOrDefault();

                    if (acao != null)
                    {
                        permissao.Add(new Permissao { FuncionalidadeId = funcionalidade.Id, AcaoId = acao.Id });
                    }
                }

            }

            return listaPermissoesAgrupadasPorFcunionalidade.SelectMany(x => x).ToList();
        }

        public override void Inserir(Perfil entidade)
        {
            entidade.Permissoes = this.RecuperarAcaoListar(entidade);

            base.Inserir(entidade);
        }

        public override void Alterar(Perfil entidade)
        {
            using (var transacao = new TransactionScope())
            {
                var entidadeBanco = this.SelecionarPorId(new Perfil { Id = entidade.Id }, new string[] { "Permissoes" });

                if (entidadeBanco.Id != 1 || entidadeBanco.Id != 2)
                {
                    entidadeBanco.Nome = entidade.Nome;
                }

                foreach (var permissao in entidadeBanco.Permissoes.ToList())
                {
                    this.PermissaoServico.Excluir(permissao);
                }

                entidade.Permissoes = this.RecuperarAcaoListar(entidade);

                foreach (var permissao in entidade.Permissoes)
                {
                    entidadeBanco.Permissoes.Add(new Permissao
                    {
                        FuncionalidadeId = this.FuncionalidadeServico.SelecionarPorId(new Funcionalidade { Id = permissao.FuncionalidadeId }).Id,
                        AcaoId = this.AcaoServico.SelecionarPorId(new Acao { Id = permissao.AcaoId }).Id
                    });
                }

                base.Alterar(entidadeBanco);

                transacao.Complete();
            }
        }
    }
}
