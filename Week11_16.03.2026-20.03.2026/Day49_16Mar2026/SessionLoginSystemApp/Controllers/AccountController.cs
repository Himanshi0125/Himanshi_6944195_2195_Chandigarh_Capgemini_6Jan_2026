using Microsoft.AspNetCore.Mvc;

namespace SessionLoginSystemApp.Controllers
{
    public class AccountController : Controller
    {

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if(username == "admin" && password == "123")
            {
                HttpContext.Session.SetString("Username", username);

                return RedirectToAction("Dashboard");
            }

            ViewBag.Error = "Invalid username or password";
            return View();
        }

        public IActionResult Dashboard()
        {
            var username = HttpContext.Session.GetString("Username");

            if(username == null)
            {
                return RedirectToAction("Login");
            }

            ViewBag.Username = username;
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Login");
        }
    }
}