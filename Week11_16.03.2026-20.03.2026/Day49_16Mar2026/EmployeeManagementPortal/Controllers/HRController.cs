using Microsoft.AspNetCore.Mvc;
using EmployeeManagementPortal.Filters;

namespace EmployeeManagementPortal.Controllers
{
    public class HRController : Controller
    {
        [ServiceFilter(typeof(LogActionFilter))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EmployeeList()
        {
            var data = EmployeeController.GetEmployees();
            return View(data);
        }

        public IActionResult Reports()
        {
            var employees = EmployeeController.GetEmployees();

            ViewBag.TotalEmployees = employees.Count;

            var deptGroups = employees
                .GroupBy(e => e.Department)
                .Select(g => new
                {
                    Department = g.Key,
                    Count = g.Count()
                }).ToList();

            ViewBag.DeptData = deptGroups;

            return View();
        }
    }
}