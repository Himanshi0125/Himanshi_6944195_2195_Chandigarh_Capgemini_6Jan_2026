using Microsoft.AspNetCore.Mvc;
using LibraryMVC.Models;
using LibraryMVC.ViewModels;

namespace LibraryMVC.Controllers
{
    public class BooksController : Controller
    {
        // Temporary in-memory list (instead of DB)
        private static List<BookViewModel> books = new List<BookViewModel>()
        {
            new BookViewModel
            {
                Book = new Book { Id = 1, Title = "C# Basics", Author = "John", PublishedYear = 2020, Genre = "Programming" },
                IsAvailable = true
            }
        };

        public IActionResult Index()
        {
            ViewBag.Message = "📚 Welcome to Library!";
            ViewData["TotalBooks"] = books.Count;

            return View(books);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BookViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Book.Id = books.Count + 1;
                books.Add(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}