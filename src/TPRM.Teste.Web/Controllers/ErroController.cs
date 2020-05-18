using System.Net;
using System.Web.Mvc;

namespace TPRM.SAP.Web.Controllers
{
    public class ErroController : Controller
    {
        public ActionResult AcessoNaoAutorizado()
        {
            return View();
        }

        public ActionResult Index()
        {
            Response.TrySkipIisCustomErrors = true;
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return View();
        }

        public ActionResult NaoEncontrado()
        {
            Response.TrySkipIisCustomErrors = true;
            Response.StatusCode = (int)HttpStatusCode.NotFound;

            return View();
        }
    }
}