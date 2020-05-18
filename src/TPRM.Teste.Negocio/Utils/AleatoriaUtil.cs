using System;

namespace TPRM.SAP.Negocio.Utils
{
    public static class AleatoriaUtil
    {
        public static long GerarNumero(double tamanho)
        {
            return (long)(new Random().NextDouble() * (9 * (long)Math.Pow(10, tamanho - 1)) + (long)Math.Pow(10, tamanho - 1));
        }
    }
}
