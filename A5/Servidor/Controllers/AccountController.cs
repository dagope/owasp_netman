using Dapper;
using Servidor.Models;
using System;
using System.Data.SqlClient;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Servidor.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login login, string returnUrl = "")
        {
            string connectionString = "Data Source=(LocalDb)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Authentication.mdf;Initial Catalog=Authentication;Integrated Security=True";
            string sql = "select Id, [Group], Name, Password from [User] where Name='" + login.Username + "' and Password='" + login.Password + "'";
            User user = new SqlConnection(connectionString).QueryFirstOrDefault<User>(sql);

            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.Name, false);
                Response.AppendCookie(new HttpCookie("Group") { Value = user.Group });

                if (Url.IsLocalUrl(returnUrl)) return Redirect(returnUrl);
                else return RedirectToAction("Account", "Home");
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            ModelState.Remove("Password");
            return View();
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Response.Cookies["Group"].Expires = DateTime.Now.AddDays(-1);
            return RedirectToAction("Index", "Home");
        }
    }
}