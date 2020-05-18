namespace TPRM.SAP.Modelo.Entidades.Sistema
{
    public class Permissao : EntidadeBase<int>
    {
        public int PerfilId { get; set; }
        public int FuncionalidadeId { get; set; }
        public int AcaoId { get; set; }

        public virtual Perfil Perfil { get; set; }
        public virtual Funcionalidade Funcionalidade { get; set; }
        public virtual Acao Acao { get; set; }
    }
}
