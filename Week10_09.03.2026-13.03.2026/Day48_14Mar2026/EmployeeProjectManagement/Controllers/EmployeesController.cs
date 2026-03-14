using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeProjectManagement.Data;
using EmployeeProjectManagement.Models;

namespace EmployeeProjectManagement.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly AppDbContext _context;

        public EmployeesController(AppDbContext context)
        {
            _context = context;
        }

        // LIST ALL EMPLOYEES
        public IActionResult Index()
        {
            var employees = _context.Employees
                .Include(e => e.Department)
                .ToList();

            return View(employees);
        }

        // CREATE PAGE
        public IActionResult Create()
        {
            ViewBag.Departments = _context.Departments.ToList();
            ViewBag.Projects = _context.Projects.ToList();

            return View();
        }

        // CREATE POST
        [HttpPost]
        public IActionResult Create(Employee employee, List<int> projectIds)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();

            foreach (var pid in projectIds)
            {
                _context.EmployeeProjects.Add(new EmployeeProject
                {
                    EmployeeId = employee.EmployeeId,
                    ProjectId = pid,
                    AssignedDate = DateTime.Now
                });
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var employee = _context.Employees.Find(id);

            ViewBag.Departments = _context.Departments.ToList();

            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            _context.Employees.Update(employee);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var employee = _context.Employees.Find(id);

            _context.Employees.Remove(employee);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}