using Dapper;
using Servidor.Models;
using System.Data.SqlClient;
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

            string sql = "select Id, Name, Password from [User] where Name='" + login.Username + "' and Password='" + login.Password + "'";
            User user = new SqlConnection(connectionString).QueryFirstOrDefault<User>(sql);

            // string sql = "select Id, Name, Password from [User] where Name=@Name and Password=@Password";
            // User user = new SqlConnection(connectionString).QueryFirstOrDefault<User>(sql, new { Name = login.Username, Password = login.Password });

            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.Name, false);

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
            return RedirectToAction("Index", "Home");
        }
    }
}