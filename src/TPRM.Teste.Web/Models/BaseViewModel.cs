using System;

namespace TPRM.SAP.Web.Models
{
    public class BaseViewModel<TipoId>
        where TipoId : IEquatable<TipoId>
    {
        public virtual TipoId Id { get; set; }
    }
}