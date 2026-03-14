using LibraryManagement.Models;

namespace LibraryManagement.Repositories
{
    public class BookRepository : IBookRepository
    {
        private List<Book> books = new List<Book>
        {
            new Book { Id = 1, Title = "C# Programming", Author = "John" },
            new Book { Id = 2, Title = "ASP.NET Core", Author = "David" },
            new Book { Id = 3, Title = "Data Structures", Author = "Alice" }
        };

        public List<Book> GetAllBooks()
        {
            return books;
        }

        public Book GetBookById(int id)
        {
            return books.FirstOrDefault(b => b.Id == id);
        }
    }
}