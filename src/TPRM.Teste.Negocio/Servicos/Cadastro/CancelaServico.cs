using System.Collections.Generic;
using System.Linq;
using TPRM.SAP.Modelo.Entidades.Cadastro;
using TPRM.SAP.Modelo.Interfaces.Repositorios.Cadastro;
using TPRM.SAP.Modelo.Interfaces.Servicos.Cadastro;
using TPRM.SAP.Negocio.Excecoes;

namespace TPRM.SAP.Negocio.Servicos.Cadastro
{
    public class CancelaServico : ServicoBase<Cancela, int, ICancelaRepositorio>, ICancelaServico
    {
        public override void Alterar(Cancela entidade)
        {
            var entidadeBanco = this.SelecionarPorId(new Cancela { Id = entidade.Id });

            if (entidadeBanco != null)
            {
                entidadeBanco.Nome = entidade.Nome;
                entidadeBanco.EstacionamentoId = entidade.EstacionamentoId;

                base.Alterar(entidadeBanco);
            }
            else
            {
                throw new EntidadeNaoExistenteException("O registro solicitado não foi encontrado ou não existe.");
            }
        }

        public override void Excluir(Cancela entidade)
        {
            var entidadeBanco = this.SelecionarPorId(new Cancela { Id = entidade.Id });

            if (entidadeBanco != null)
            {
                base.Excluir(entidadeBanco);
            }
            else
            {
                throw new EntidadeNaoExistenteException("O registro solicitado não foi encontrado ou não existe.");
            }
        }

        public List<Cancela> SelecionarPorEstacionamento(int estacionamentoId)
        {
            return this.RepositorioBase.SelecionarPor(x => x.EstacionamentoId == estacionamentoId).ToList();
        }
    }
}
