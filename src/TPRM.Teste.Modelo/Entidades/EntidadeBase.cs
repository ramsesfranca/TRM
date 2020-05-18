namespace TPRM.SAP.Modelo.Entidades
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TipoId"></typeparam>
    public abstract class EntidadeBase<TipoId>
    {
        /// <summary>
        /// 
        /// </summary>
        public TipoId Id { get; set; }
    }
}
