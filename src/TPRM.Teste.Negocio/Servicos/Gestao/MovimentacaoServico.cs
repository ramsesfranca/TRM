using Microsoft.Practices.Unity;
using System;
using System.Linq;
using System.Transactions;
using TPRM.SAP.Modelo.Entidades.Gestao;
using TPRM.SAP.Modelo.Entidades.Sistema;
using TPRM.SAP.Modelo.Enums;
using TPRM.SAP.Modelo.Interfaces.Repositorios.Gestao;
using TPRM.SAP.Modelo.Interfaces.Servicos.Gestao;
using TPRM.SAP.Modelo.Interfaces.Servicos.Sistema;
using TPRM.SAP.Negocio.Excecoes;
using TPRM.SAP.Negocio.Utils;

namespace TPRM.SAP.Negocio.Servicos.Gestao
{
    public class MovimentacaoServico : ServicoBase<Movimentacao, int, IMovimentacaoRepositorio>, IMovimentacaoServico
    {
        [Dependency]
        public ICompetenciaServico CompetenciaServico { private get; set; }
        [Dependency]
        public IUsuarioServico UsuarioServico { private get; set; }

        private decimal CalcularValorPagarInterno(Movimentacao entidadebanco)
        {
            return Convert.ToDecimal(Convert.ToInt32((DateTime.Now - entidadebanco.DataHoraEntrada).TotalMinutes) * 0.13D);
        }

        public string EstadaVeiculo(Movimentacao entidade)
        {
            var usuario = this.UsuarioServico.SelecionarPorId(new Usuario { Id = 4 },
                new string[] { "Cancela.Estacionamento" });

            entidade.DataHoraEntrada = DateTime.Now;
            entidade.Ticket = AleatoriaUtil.GerarNumero(10).ToString();
            entidade.ClienteId = usuario.Cancela.Estacionamento.ClienteId;

            base.Inserir(entidade);

            return entidade.Ticket;
        }

        public void SaidaVeiculo(int id)
        {
            using (var transacao = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                var entidadeBanco = this.SelecionarPorId(new Movimentacao { Id = id });
                var usuario = this.UsuarioServico.SelecionarPorId(new Usuario { Id = 4 },
                    new string[] { "Cancela.Estacionamento" });

                entidadeBanco.TipoMovimentacao = TipoMovimentacao.Saida;
                entidadeBanco.DataHoraSaida = DateTime.Now;

                base.Alterar(entidadeBanco);
                this.CompetenciaServico.Inserir(new Competencia
                {
                    Valor = (this.CalcularValorPagarInterno(entidadeBanco) / 100) * 5,
                    Mes = DateTime.Now.Month,
                    Ano = DateTime.Now.Year,
                    Pago = false,
                    MovimentacaoId = entidadeBanco.Id,
                    ClienteId = usuario.Cancela.Estacionamento.ClienteId
                });

                transacao.Complete();
            }
        }

        public Movimentacao SelecionarPorTicket(string ticket)
        {
            return this.RepositorioBase
                .SelecionarPor(x => x.Ticket == ticket && x.TipoMovimentacao == TipoMovimentacao.Entrada)
                .FirstOrDefault();
        }

        public decimal CalcularValorPagar(int id)
        {
            var entidadebanco = this.SelecionarPorId(new Movimentacao { Id = id });

            if (entidadebanco != null)
            {
                return CalcularValorPagarInterno(entidadebanco);
            }
            else
            {
                throw new EntidadeNaoExistenteException("Não existe nenhum ticket cadastrado na base de dados.");
            }
        }
    }
}
