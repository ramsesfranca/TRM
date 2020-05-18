using System.Collections.Generic;
using TPRM.SAP.Modelo.Entidades.Sistema;

namespace TPRM.SAP.Modelo
{
    public class UsuarioSessao
    {
        public int PerfilId { get; set; }
        public int UsuarioId { get; set; }
        public List<Permissao> ListaPermissao { get; set; }
    }
}
