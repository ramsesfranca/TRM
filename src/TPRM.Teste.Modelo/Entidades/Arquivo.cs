using System;

namespace TPRM.SAP.Modelo.Entidades
{
    public class Arquivo : EntidadeBase<int>
    {
        public string NomeOriginal { get; set; }
        public string CaminhoServidor{ get; set; }
        public string Extensao { get; set; }
        public int Tamanho { get; set; }
        public DateTime DataCarregamento { get; set; }
        public byte[] ArquivoByte { get; set; }
    }
}
