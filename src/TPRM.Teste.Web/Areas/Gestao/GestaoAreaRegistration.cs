using System.Web.Mvc;

namespace TPRM.SAP.Web.Areas.Gestao
{
    public class GestaoAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Gestao";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Gestao_default",
                "Gestao/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}