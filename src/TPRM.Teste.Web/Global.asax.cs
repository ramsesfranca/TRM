using Microsoft.Practices.Unity;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TPRM.SAP.Negocio;
using TPRM.SAP.Web.CustomModelBinder;
using TPRM.SAP.Web.Mappers;

namespace TPRM.SAP.Web
{
    public class MvcApplication : HttpApplication
    {
        public static IUnityContainer Container { get; private set; }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ConfuguracaoAutoMapper.RegistrarMapeamentos();

            ModelBinders.Binders.Add(typeof(decimal), new DecimalModelBinder());

            ClientDataTypeModelValidatorProvider.ResourceClassKey = "Recurso";
            DefaultModelBinder.ResourceClassKey = "Recurso";

            Container = new UnityContainer().CarregarConfiguracoes();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();
            HttpException httpException = exception as HttpException;
        }
    }
}
