using System.IO;
using System.Web;
using TPRM.SAP.Modelo.Entidades;

namespace TPRM.SAP.Web.Helpers
{
    public static class CustomExtensionHelper
    {
        public static Arquivo LerArquivo(this HttpPostedFileBase arquivo, string tipoDocumento = null, string nomeDocumento = null)
        {
            Arquivo arquivoAnexo = null;

            if (arquivo != null && arquivo.ContentLength > 0)
            {
                byte[] arquivoBytes = new byte[arquivo.ContentLength];

                arquivo.InputStream.Read(arquivoBytes, 0, arquivo.ContentLength);

                arquivoAnexo = new Arquivo
                {
                    ArquivoByte = arquivoBytes,
                    NomeOriginal = !string.IsNullOrWhiteSpace(nomeDocumento) ? nomeDocumento + Path.GetExtension(arquivo.FileName) : arquivo.FileName,
                    Tamanho = arquivo.ContentLength,
                    Extensao = Path.GetExtension(arquivo.FileName)
                };
            }

            return arquivoAnexo;
        }
    }
}
