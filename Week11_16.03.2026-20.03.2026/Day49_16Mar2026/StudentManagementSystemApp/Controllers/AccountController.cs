using Microsoft.AspNetCore.Mvc;

namespace StudentManagementSystemApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if(username=="admin" && password=="123")
            {
                HttpContext.Session.SetString("User", username);
                return RedirectToAction("Dashboard");
            }

            ViewBag.Error = "Invalid credentials";
            return View();
        }

        public IActionResult Dashboard()
        {
            var user = HttpContext.Session.GetString("User");

            if(user == null)
                return RedirectToAction("Login");

            ViewBag.User = user;
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}