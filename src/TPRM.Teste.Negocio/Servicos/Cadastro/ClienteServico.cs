using TPRM.SAP.Modelo.Entidades.Cadastro;
using TPRM.SAP.Modelo.Interfaces.Repositorios.Cadastro;
using TPRM.SAP.Modelo.Interfaces.Servicos.Cadastro;
using TPRM.SAP.Negocio.Excecoes;

namespace TPRM.SAP.Negocio.Servicos.Cadastro
{
    public class ClienteServico : ServicoBase<Cliente, int, IClienteRepositorio>, IClienteServico
    {
        public override void Alterar(Cliente entidade)
        {
            var entidadeBanco = this.SelecionarPorId(new Cliente { Id = entidade.Id });

            if (entidadeBanco != null)
            {
                entidadeBanco.Nome = entidade.Nome;
                entidadeBanco.CNPJ = entidade.CNPJ;
                entidadeBanco.Email = entidade.Email;

                base.Alterar(entidadeBanco);
            }
            else
            {
                throw new EntidadeNaoExistenteException("O registro solicitado não foi encontrado ou não existe.");
            }
        }

        public override void Excluir(Cliente entidade)
        {
            var entidadeBanco = this.SelecionarPorId(new Cliente { Id = entidade.Id });

            if (entidadeBanco != null)
            {
                base.Excluir(entidadeBanco);
            }
            else
            {
                throw new EntidadeNaoExistenteException("O registro solicitado não foi encontrado ou não existe.");
            }
        }
    }
}
