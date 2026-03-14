using Microsoft.AspNetCore.Mvc;
using System.Linq;
using EfCoreCodeFirstApproachDemo01.Models;

public class EmployeeModelsController : Controller
{
    private readonly EmployeeDBContext _context;

    public EmployeeModelsController(EmployeeDBContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var employees = _context.employees.ToList();
        return View(employees);
    }
    // GET: EmployeeModels/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: EmployeeModels/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(EmployeeModel emp)
    {
        if (ModelState.IsValid)
        {
            _context.employees.Add(emp);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(emp);
    }
}