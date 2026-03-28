using Microsoft.AspNetCore.Mvc;
using EmployeeManagementPortal.Models;

namespace EmployeeManagementPortal.Controllers
{
    public class EmployeeController : Controller
    {
        static List<Employee> employees = new List<Employee>();
        static int nextId = 1;

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Employee emp)
        {
            if(ModelState.IsValid)
            {
                emp.Id = nextId++;
                employees.Add(emp);

                TempData["Success"] = "Employee Registered Successfully!";

                return RedirectToAction("Details", new { id = emp.Id });
            }

            return View(emp);
        }

        public IActionResult Details(int id)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);
            return View(emp);
        }

        public static List<Employee> GetEmployees()
        {
            return employees;
        }
    }
}