using LibraryMVC.Models;

namespace LibraryMVC.ViewModels
{
    public class BookViewModel
    {
        public Book Book { get; set; }

        public bool IsAvailable { get; set; }

        // Practice extension
        public string? BorrowerName { get; set; }
    }
}