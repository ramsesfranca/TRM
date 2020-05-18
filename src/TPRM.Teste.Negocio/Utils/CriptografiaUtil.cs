using System;
using System.Security.Cryptography;
using System.Text;

namespace TPRM.SAP.Negocio.Utils
{
    /// <summary>
    /// 
    /// </summary>
    public static class CriptografiaUtil
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="senha"></param>
        /// <returns></returns>
        public static string Criptografar(string senha)
        {
            return Convert.ToBase64String(new SHA256CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(senha)));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stringNormal"></param>
        /// <param name="stringCriptografada"></param>
        /// <returns></returns>
        public static bool Comparar(string stringNormal, string stringCriptografada)
        {
            return stringCriptografada.Equals(Convert.ToBase64String(new SHA256CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(stringNormal))));
        }
    }
}
