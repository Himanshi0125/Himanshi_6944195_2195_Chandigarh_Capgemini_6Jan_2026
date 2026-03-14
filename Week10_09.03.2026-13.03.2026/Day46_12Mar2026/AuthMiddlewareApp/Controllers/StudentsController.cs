using Microsoft.AspNetCore.Mvc;

namespace AuthMiddlewareApp.Controllers
{
    public class StudentsController : Controller
    {
        public IActionResult Index()
        {
            return Content("Public Students Page");
        }
    }
}