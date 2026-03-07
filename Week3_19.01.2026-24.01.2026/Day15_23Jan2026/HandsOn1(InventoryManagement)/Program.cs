using System;
using System.Collections.Generic;
using System.Linq;

class Book
{
    public string Title { get; set; }
    public double Price { get; set; }
    public int Stock { get; set; }
}

class Program
{
    static void Main()
    {
        List<Book> inventory = new List<Book>();

        inventory.Add(new Book { Title = "C# Basics", Price = 450, Stock = 10 });
        inventory.Add(new Book { Title = "LINQ in Action", Price = 600, Stock = 5 });
        inventory.Add(new Book { Title = "ASP.NET Core", Price = 800, Stock = 0 });
        inventory.Add(new Book { Title = "Data Structures", Price = 300, Stock = 8 });

        Console.WriteLine("Initial Inventory:");
        DisplayBooks(inventory);

        double targetPrice = 500;
        var cheapBooks = inventory.Where(b => b.Price < targetPrice);

        Console.WriteLine("\nBooks cheaper than " + targetPrice + ":");
        DisplayBooks(cheapBooks.ToList());

        inventory.ForEach(b => b.Price += b.Price * 0.10);

        Console.WriteLine("\nAfter 10% Price Increase:");
        DisplayBooks(inventory);

        inventory = inventory.Where(b => b.Stock > 0).ToList();

        Console.WriteLine("\nAfter Removing Out-of-Stock Books:");
        DisplayBooks(inventory);
    }

    static void DisplayBooks(List<Book> books)
    {
        foreach (var book in books)
        {
            Console.WriteLine(
                $"Title: {book.Title}, Price: {book.Price}, Stock: {book.Stock}"
            );
        }
    }
}
