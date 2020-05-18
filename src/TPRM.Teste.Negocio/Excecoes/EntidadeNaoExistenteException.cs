using System;

namespace TPRM.SAP.Negocio.Excecoes
{
    /// <summary>
    /// Representa os erros que ocorrem durante a execução do aplicativo.
    /// </summary>
    public class EntidadeNaoExistenteException : Exception
    {
        /// <summary>
        /// Inicializa uma nova instância da classe de exceção com uma mensagem de erro especificado.
        /// </summary>
        /// <param name="mensagem">A mensagem que descreve o erro.</param>
        public EntidadeNaoExistenteException(string mensagem)
            : base(mensagem)
        {
        }
    }
}
