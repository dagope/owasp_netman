using System.Web.Mvc;

namespace Servidor.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Account()
        {
            return View();
        }

        [Authorize]
        public ActionResult Manage()
        {
            if (Request.Cookies["Group"].Value == "Administrators") return View();
            else return new HttpUnauthorizedResult();
        }
    }
}