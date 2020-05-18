using System.Collections.Generic;
using System.Linq;
using TPRM.SAP.Modelo.Entidades.Cadastro;
using TPRM.SAP.Modelo.Interfaces.Repositorios.Cadastro;
using TPRM.SAP.Modelo.Interfaces.Servicos.Cadastro;
using TPRM.SAP.Negocio.Excecoes;

namespace TPRM.SAP.Negocio.Servicos.Cadastro
{
    public class EstacionamentoServico : ServicoBase<Estacionamento, int, IEstacionamentoRepositorio>, IEstacionamentoServico
    {
        public override void Alterar(Estacionamento entidade)
        {
            var entidadeBanco = this.SelecionarPorId(new Estacionamento { Id = entidade.Id });

            if (entidadeBanco != null)
            {
                entidadeBanco.Nome = entidade.Nome;
                entidadeBanco.Endereco = entidade.Endereco;
                entidadeBanco.QtdVagas = entidade.QtdVagas;
                entidadeBanco.ClienteId = entidade.ClienteId;

                base.Alterar(entidadeBanco);
            }
            else
            {
                throw new EntidadeNaoExistenteException("O registro solicitado não foi encontrado ou não existe.");
            }
        }

        public override void Excluir(Estacionamento entidade)
        {
            var entidadeBanco = this.SelecionarPorId(new Estacionamento { Id = entidade.Id });

            if (entidadeBanco != null)
            {
                base.Excluir(entidadeBanco);
            }
            else
            {
                throw new EntidadeNaoExistenteException("O registro solicitado não foi encontrado ou não existe.");
            }
        }

        public List<Estacionamento> SelecionarPorCliente(int clienteId)
        {
            return this.RepositorioBase.SelecionarPor(x => x.ClienteId == clienteId).ToList();
        }
    }
}
