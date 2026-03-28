using Microsoft.AspNetCore.Mvc;
using StudentRegistrationApp.Models;

namespace StudentRegistrationApp.Controllers
{
    public class StudentController : Controller
    {
        static List<Student> students = new List<Student>();
        static int nextId = 1;

        // GET: Student/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: Student/Register
        [HttpPost]
        public IActionResult Register(Student student)
        {
            if (ModelState.IsValid)
            {
                student.Id = nextId++;
                students.Add(student);

                TempData["SuccessMessage"] = "Student Registered Successfully!";

                return RedirectToAction("Details", new { id = student.Id });
            }

            return View(student);
        }

        // GET: Student/Details
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