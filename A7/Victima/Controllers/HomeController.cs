using System.Collections.Generic;
using System.Web.Mvc;

namespace A7.Controllers
{
    public class HomeController : Controller
    {
        static List<string> Comments = new List<string>();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            ViewBag.Comments = Comments;

            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Contact(string comment)
        {
            Comments.Add(comment);

            ViewBag.Message = "Your contact page.";
            ViewBag.Comments = Comments;

            return View();
        }
    }
}