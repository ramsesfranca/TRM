using System;

namespace TPRM.SAP.Negocio.Excecoes
{
    public class ArquivoInvalidaException : Exception
    {
        public ArquivoInvalidaException(string mensagem)
            : base(mensagem)
        {
        }
    }
}
