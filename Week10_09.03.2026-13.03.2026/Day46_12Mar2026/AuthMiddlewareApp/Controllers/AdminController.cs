using Microsoft.AspNetCore.Mvc;

namespace AuthMiddlewareApp.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Dashboard()
        {
            return Content("Welcome to Admin Dashboard");
        }
    }
}