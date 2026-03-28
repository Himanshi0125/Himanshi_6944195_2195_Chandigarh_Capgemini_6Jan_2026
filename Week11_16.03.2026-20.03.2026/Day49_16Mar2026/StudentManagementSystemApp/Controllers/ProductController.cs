using Microsoft.AspNetCore.Mvc;
using StudentManagementSystemApp.Models;
using StudentManagementSystemApp.Filters;

namespace StudentManagementSystemApp.Controllers
{
    public class ProductController : Controller
    {
        static List<Product> products = new List<Product>()
        {
            new Product{Id=1, Name="Laptop", Price=75000},
            new Product{Id=2, Name="Phone", Price=40000}
        };

        [ServiceFilter(typeof(LogActionFilter))]
        public IActionResult Index()
        {
            return View(products);
        }

        public IActionResult Details(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            return View(product);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            product.Id = products.Count + 1;
            products.Add(product);

            return RedirectToAction("Index");
        }
    }
}