using System.Data.Entity;

namespace TPRM.SAP.Repositorio
{
    public class SAPContexto : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        public SAPContexto()
            : base("ModeloContainer")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = true;
        }
    }
}
