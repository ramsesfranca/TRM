using System.ComponentModel;

namespace TPRM.SAP.Modelo.Enums
{
    public enum TipoMovimentacao
    {
        [Description("Entrada")]
        Entrada = 1,
        [Description("Saída")]
        Saida = 2
    }
}
