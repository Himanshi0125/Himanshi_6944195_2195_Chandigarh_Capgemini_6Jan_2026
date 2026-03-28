using Microsoft.AspNetCore.Mvc;
using StudentManagementSystemApp.Models;

namespace StudentManagementSystemApp.Controllers
{
    public class StudentController : Controller
    {
        static List<Student> students = new List<Student>();
        static int nextId = 1;

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Student student)
        {
            if(ModelState.IsValid)
            {
                student.Id = nextId++;
                students.Add(student);

                TempData["Success"] = "Student Registered Successfully!";

                return RedirectToAction("Details", new { id = student.Id });
            }

            return View(student);
        }

        public IActionResult Details(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            return View(student);
        }
        public IActionResult Index()
        {
            return View(students);
        }
    }
}