using System;
using System.Linq;
using TPRM.SAP.Modelo.Entidades.Sistema;
using TPRM.SAP.Modelo.Enums;
using TPRM.SAP.Modelo.Interfaces.Repositorios.Sistema;
using TPRM.SAP.Modelo.Interfaces.Servicos.Sistema;
using TPRM.SAP.Negocio.Excecoes;
using TPRM.SAP.Negocio.Utils;

namespace TPRM.SAP.Negocio.Servicos.Sistema
{
    public class UsuarioServico : ServicoBase<Usuario, int, IUsuarioRepositorio>, IUsuarioServico
    {
        public override void Inserir(Usuario entidade)
        {
            entidade.Status = Status.Ativo;
            entidade.Senha = CriptografiaUtil.Criptografar(entidade.Senha);

            base.Inserir(entidade);
        }

        public override void Alterar(Usuario entidade)
        {
            var entidadeBanco = this.SelecionarPorId(new Usuario { Id = entidade.Id });

            if (entidadeBanco != null)
            {
                entidadeBanco.Nome = entidade.Nome;
                entidadeBanco.CPF = entidade.CPF;
                entidadeBanco.Email = entidade.Email;
                entidadeBanco.Login = entidade.Login;
                entidadeBanco.PerfilId = entidade.PerfilId;

                if (entidade.PerfilId == 2)
                {
                    entidadeBanco.CancelaId = entidade.CancelaId;
                }
                else
                {
                    entidadeBanco.CancelaId = null;
                }
                if (!string.IsNullOrWhiteSpace(entidade.Senha))
                {
                    entidadeBanco.Senha = CriptografiaUtil.Criptografar(entidade.Senha);
                }

                base.Alterar(entidadeBanco);
            }
            else
            {
                throw new EntidadeNaoExistenteException("Não existe nenhum registro cadastrado na base de dados.");
            }
        }

        public override void Excluir(Usuario entidade)
        {
            var entidadeBanco = this.SelecionarPorId(new Usuario { Id = entidade.Id });

            if (entidadeBanco != null)
            {
                entidadeBanco.Status = Status.Inativo;

                base.Alterar(entidadeBanco);
            }
            else
            {
                throw new EntidadeNaoExistenteException("Não existe nenhum registro cadastrado na base de dados.");
            }
        }

        public bool ValidarLogin(string login, string senha)
        {
            var retorno = false;
            var entidadeBanco = this.RepositorioBase.SelecionarPor(x => x.Login.Equals(login)).FirstOrDefault();

            if (entidadeBanco != null)
            {
                if (CriptografiaUtil.Comparar(senha, entidadeBanco.Senha))
                {
                    entidadeBanco.DataHoraLogin = DateTime.Now;
                    base.Alterar(entidadeBanco);
                    retorno = true;
                }
            }
            else
            {
                throw new EntidadeNaoExistenteException("O registro solicitado não foi encontrado ou não existe.");
            }

            return retorno;
        }

        public Usuario SelecionarPeloNome(string login)
        {
            return this.RepositorioBase.SelecionarPor(x => x.Login.Equals(login), new string[] { "Perfil" })
                .FirstOrDefault();
        }
    }
}
