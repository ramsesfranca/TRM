using TPRM.SAP.Modelo.Enums;

namespace TPRM.SAP.Web.Areas.Sistema.Models
{
    public class AlterarUsuarioViewModel : InserirUsuarioViewModel
    {
        public int Id { get; set; }

        public AlterarPerfilViewModel Perfil { get; set; }

        public Status Status { get; set; }
    }
}
