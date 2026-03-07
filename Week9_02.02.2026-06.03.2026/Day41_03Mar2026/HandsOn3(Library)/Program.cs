using System;
using System.Collections.Generic;
using System.Linq;

public interface IBook
{
    int Id { get; set; }
    string Title { get; set; }
    string Author { get; set; }
    string Category { get; set; }
    int Price { get; set; }
}

public class Book : IBook
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Category { get; set; }
    public int Price { get; set; }

    public Book(int id, string title, string author, string category, int price)
    {
        Id = id;
        Title = title;
        Author = author;
        Category = category;
        Price = price;
    }
}

public interface ILibrarySystem
{
    void AddBook(IBook book, int quantity);
    void RemoveBook(IBook book, int quantity);
    int CalculateTotal();
    List<(string,string,int)> CategoryAndAuthorWithCount();
    List<(string,int)> CategoryTotalPrice();
    List<(string,int,int)> BooksInfo();
}

public class LibrarySystem : ILibrarySystem
{
    private Dictionary<IBook, int> _books = new Dictionary<IBook, int>();

    public void AddBook(IBook book, int quantity)
    {
        var existing = _books.Keys.FirstOrDefault(b => b.Id == book.Id);

        if (existing != null)
            _books[existing] += quantity;
        else
            _books.Add(book, quantity);
    }

    public void RemoveBook(IBook book, int quantity)
    {
        var existing = _books.Keys.FirstOrDefault(b => b.Id == book.Id);

        if (existing != null)
        {
            _books[existing] -= quantity;

            if (_books[existing] <= 0)
                _books.Remove(existing);
        }
    }

    public int CalculateTotal()
    {
        return _books.Sum(x => x.Key.Price * x.Value);
    }

    public List<(string,int,int)> BooksInfo()
    {
        return _books
        .Select(x => (x.Key.Title, x.Value, x.Key.Price))
        .OrderBy(x => x.Title)
        .ToList();
    }

    public List<(string,int)> CategoryTotalPrice()
    {
        return _books
        .GroupBy(x => x.Key.Category)
        .Select(g => (g.Key, g.Sum(x => x.Key.Price * x.Value)))
        .OrderBy(x => x.Key)
        .ToList();
    }

    public List<(string,string,int)> CategoryAndAuthorWithCount()
    {
        return _books
        .GroupBy(x => new { x.Key.Category, x.Key.Author })
        .Select(g => (g.Key.Category, g.Key.Author, g.Sum(x => x.Value)))
        .OrderBy(x => x.Category)
        .ThenBy(x => x.Author)
        .ToList();
    }
}

public class Solution
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        LibrarySystem library = new LibrarySystem();

        for(int i=0;i<n;i++)
        {
            var parts = Console.ReadLine().Split();

            int id = int.Parse(parts[0]);
            string title = parts[1];
            string author = parts[2];
            string category = parts[3];
            int price = int.Parse(parts[4]);
            int quantity = int.Parse(parts[5]);

            Book book = new Book(id,title,author,category,price);

            library.AddBook(book, quantity);
        }

        Console.WriteLine("Book Info:");
        foreach(var b in library.BooksInfo())
        {
            Console.WriteLine($"Book Name:{b.Item1}, Quantity:{b.Item2}, Price:{b.Item3}");
        }

        Console.WriteLine("Category Total Price:");
        foreach(var c in library.CategoryTotalPrice())
        {
            Console.WriteLine($"Category:{c.Item1}, Total Price:{c.Item2}");
        }

        Console.WriteLine("Category And Author With Count:");
        foreach(var ca in library.CategoryAndAuthorWithCount())
        {
            Console.WriteLine($"Category:{ca.Item1}, Author:{ca.Item2}, Count:{ca.Item3}");
        }

        Console.WriteLine($"Total Price: {library.CalculateTotal()}");
    }
}