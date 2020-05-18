using System;
using System.IO;
using System.Web;

namespace TPRM.SAP.Negocio.Utils
{
    /// <summary>
    /// 
    /// </summary>
    public static class IOUtil
    {
        /// <summary>
        /// Obtém o caminho do servidor baseado no Diretório aonde o documento será salvo.
        /// </summary>
        /// <param name="diretorio">Diretório aonde o arquivo vai ser salvo no servidor.</param>
        /// <returns>Retorar diretório aonde o arquivo vai ser salvo.</returns>
        private static string ObterCaminhoParaTipo(string diretorio)
        {
            return @"Uploads\Documentos\" + diretorio + "\\";
        }

        /// <summary>
        /// Método responsável por gerar o caminho  do arquivo no documento.
        /// </summary>
        /// <param name="nomeArquivo">Parâmetro para geração do path.</param>
        /// <param name="diretorio">Parâmetro para geração do caminho.</param>
        /// <param name="gerarNomeArquivo">Nome do arquivo gerado no caminho.</param>
        /// <returns>Retorna o caminho do arquivo.</returns>
        public static string GerarCaminhoArquivoDocumento(string nomeArquivo, string diretorio, bool gerarNomeArquivo = false)
        {
            if (gerarNomeArquivo != false)
            {
                return HttpContext.Current.Server.MapPath("~/") + ObterCaminhoParaTipo(diretorio) + Guid.NewGuid().ToString() + Path.GetExtension(nomeArquivo);
            }
            else
            {
                return HttpContext.Current.Server.MapPath("~/") + ObterCaminhoParaTipo(diretorio) + nomeArquivo;
            }
        }

        /// <summary>
        /// Método que vai salvar o arquivo fisicamente no servidor.
        /// </summary>
        /// <param name="caminhoArquivo"></param>
        /// <param name="arrayByte"></param>
        /// <returns></returns>
        public static bool SalvarArquivo(string caminhoArquivo, byte[] arrayByte)
        {
            FileStream fileStream = null;

            try
            {
                fileStream = new FileStream(caminhoArquivo, FileMode.Create, FileAccess.Write);
                fileStream.Write(arrayByte, 0, arrayByte.Length);
                return true;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (fileStream != null)
                {
                    fileStream.Close();
                }
            }
        }

        /// <summary>
        /// Método que vai remover fisicamente o arquivo no servidor.
        /// </summary>
        /// <param name="caminhoArquivo"></param>
        /// <returns></returns>
        public static bool RemoverArquivo(string caminhoArquivo)
        {
            var retorno = true;

            try
            {
                File.Delete(caminhoArquivo);
            }
            catch
            {
                retorno = false;
            }

            return retorno;
        }

        /// <summary>
        /// Método que vai retonar o arquivo.
        /// </summary>
        /// <param name="caminhoArquivo"></param>
        /// <returns></returns>
        public static byte[] CarregarArquivo(string caminhoArquivo)
        {
            return File.ReadAllBytes(caminhoArquivo);
        }
    }
}
