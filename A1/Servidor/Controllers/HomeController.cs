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
    }
}