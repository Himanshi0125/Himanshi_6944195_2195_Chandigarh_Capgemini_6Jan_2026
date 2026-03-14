using Microsoft.AspNetCore.Mvc;
using StudentPortal.Models;
using StudentPortal.Services;

namespace StudentPortal.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IRequestLogService _logService;

        public StudentsController(IRequestLogService logService)
        {
            _logService = logService;
        }

        public IActionResult Index()
        {
            var students = new List<Student>
            {
                new Student{ Id=1, Name="Amit", Course="CSE"},
                new Student{ Id=2, Name="Priya", Course="IT"},
                new Student{ Id=3, Name="Rahul", Course="AI"}
            };

            ViewBag.Logs = _logService.GetLogs();

            return View(students);
        }
    }
}