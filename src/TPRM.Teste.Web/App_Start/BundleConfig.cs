using System.Web.Optimization;

namespace TPRM.SAP.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate.js",
                "~/Scripts/jquery.validate.unobtrusive.js",
                "~/Scripts/jquery.validate.unobtrusive.bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/sitemodal").Include(
                "~/Scripts/modalBootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/formulario").Include(
                "~/Scripts/globalize.0.1.3/globalize.js",
                "~/Scripts/globalize.0.1.3/cultures/globalize.culture.pt-BR.js",
                "~/Scripts/jquery.maskedinput.js",
                "~/Scripts/jquery.moneymask.js",
                "~/Scripts/jquery.charactercounter.js",
                //"~/Scripts/formulario.globalizado.js",
                "~/Scripts/formulario.js",
                "~/Scripts/contadorcaracter.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/font-awesome.css",
                "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/cancela").Include(
                "~/Scripts/paginas/cancela.js"));

            bundles.Add(new ScriptBundle("~/bundles/usuario").Include(
                "~/Scripts/paginas/usuario.js"));
        }
    }
}
