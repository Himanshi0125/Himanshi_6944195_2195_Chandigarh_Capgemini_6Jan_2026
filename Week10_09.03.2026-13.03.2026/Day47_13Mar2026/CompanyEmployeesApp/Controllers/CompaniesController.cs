using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CompanyEmployeesApp.Data;

namespace CompanyEmployeesApp.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CompaniesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var companies = await _context.Companies
                .Include(c => c.Employees)
                .ToListAsync();

            return View(companies);
        }
    }
}