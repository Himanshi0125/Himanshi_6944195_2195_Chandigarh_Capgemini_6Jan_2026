using Microsoft.AspNetCore.Mvc;
using ProductManagementFiltersApp.Models;
using ProductManagementFiltersApp.Filters;

namespace ProductManagementFiltersApp.Controllers
{
    public class ProductController : Controller
    {
        static List<Product> products = new List<Product>()
        {
            new Product { Id = 1, Name = "Laptop", Price = 75000 },
            new Product { Id = 2, Name = "Smartphone", Price = 40000 },
            new Product { Id = 3, Name = "Headphones", Price = 5000 }
        };

        [ServiceFilter(typeof(LogActionFilter))]
        public IActionResult Index()
        {
            // Testing Exception Filter
            // throw new Exception("Testing exception filter");

            return View(products);
        }
    }
}