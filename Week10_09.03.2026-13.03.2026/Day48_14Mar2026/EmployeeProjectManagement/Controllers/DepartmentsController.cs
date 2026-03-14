using Microsoft.AspNetCore.Mvc;
using EmployeeProjectManagement.Data;
using EmployeeProjectManagement.Models;

namespace EmployeeProjectManagement.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly AppDbContext _context;

        public DepartmentsController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var departments = _context.Departments.ToList();
            return View(departments);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var department = _context.Departments.Find(id);

            return View(department);
        }

        [HttpPost]
        public IActionResult Edit(Department department)
        {
            _context.Departments.Update(department);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var department = _context.Departments.Find(id);

            _context.Departments.Remove(department);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}