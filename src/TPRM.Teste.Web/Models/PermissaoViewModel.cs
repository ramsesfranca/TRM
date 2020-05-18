namespace TPRM.SAP.Web.Models
{
    public class PermissaoViewModel : BaseViewModel<int>
    {
        public int PerfilId { get; set; }
        public int FuncionalidadeId { get; set; }
        public int AcaoId { get; set; }

        //public AlterarPerfilViewModel Perfil { get; set; }
        public FuncionalidadeViewModel Funcionalidade { get; set; }
        public AcaoViewModel Acao { get; set; }
    }
}