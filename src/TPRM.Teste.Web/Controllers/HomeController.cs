using System.Web.Mvc;
using TPRM.SAP.Web.Filters;

namespace TPRM.SAP.Web.Controllers
{
    public class HomeController : BaseController
    {
        [SAPAutorizarAttribute]
        public ActionResult Index()
        {
            return View();
        }
    }
}
