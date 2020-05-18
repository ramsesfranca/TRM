using Microsoft.Practices.Unity;
using PagedList;
using System;
using System.Linq;
using System.Text;
using System.Transactions;
using TPRM.SAP.Modelo.Entidades.Cadastro;
using TPRM.SAP.Modelo.Entidades.Gestao;
using TPRM.SAP.Modelo.Interfaces.Repositorios.Gestao;
using TPRM.SAP.Modelo.Interfaces.Servicos.Cadastro;
using TPRM.SAP.Modelo.Interfaces.Servicos.Gestao;
using TPRM.SAP.Negocio.Utils;

namespace TPRM.SAP.Negocio.Servicos.Gestao
{
    public class CompetenciaServico : ServicoBase<Competencia, int, ICompetenciaRepositorio>, ICompetenciaServico
    {
        [Dependency]
        public IClienteServico ClienteServico { private get; set; }

        public override IPagedList<Competencia> SelecionarTodos(Competencia entidade, int numeroPagina, int tamanhoPagina, params string[] entidadeNavegacao)
        {
            var listaCompetencia = this.RepositorioBase.SelecionarPor(x => x.Mes == DateTime.Now.Month && x.Ano == DateTime.Now.Year).ToList()
                .GroupBy(x => new { x.Mes, x.Ano })
                .Select(x => new Competencia
                {
                    Mes = x.Key.Mes,
                    Ano = x.Key.Ano,
                    Valor = x.Select(y => y.Valor).Sum(),
                    Pago = x.Select(y => y).First().Pago,
                    ClienteId = x.Select(y => y).First().ClienteId
                }).ToList();

            return listaCompetencia.OrderByDescending(x => x.Id).ToPagedList(numeroPagina, tamanhoPagina);
        }

        public void Pagar(int clienteId)
        {
            using (var transacao = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                var listaCompetencia = this.RepositorioBase.SelecionarPor(x => x.ClienteId == clienteId).ToList();

                listaCompetencia.Select(x => { x.Pago = true; return x; }).ToList();

                foreach (var Competencia in listaCompetencia)
                {
                    base.Alterar(Competencia);
                }

                transacao.Complete();
            }
        }

        public void EnviarEmailCobranca(int clienteId, int mes, int ano)
        {
            var cliente = this.ClienteServico
                .SelecionarPorId(new Cliente { Id = clienteId });
            var valor = this.RepositorioBase
                .SelecionarPor(x => x.ClienteId == clienteId && x.Mes == mes && x.Ano == ano)
                .Select(x => x.Valor)
                .Sum();

            var corpoEmail = new StringBuilder();

            corpoEmail.Append("Mês: " + mes + "\n");
            corpoEmail.Append("Ano: " + ano + "\n");
            corpoEmail.Append("Valor: " + valor + "\n");

            EmailUtil.EnviarEmail(cliente.Email, "Cobrança", corpoEmail.ToString());
        }
    }
}
