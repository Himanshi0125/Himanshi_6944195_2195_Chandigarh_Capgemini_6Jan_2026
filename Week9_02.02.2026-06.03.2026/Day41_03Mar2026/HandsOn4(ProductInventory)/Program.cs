using System;
using System.Collections.Generic;
using System.Linq;

public interface IProduct
{
    string Name { get; set; }
    string Category { get; set; }
    int Stock { get; set; }
    int Price { get; set; }
}

public class Product : IProduct
{
    public string Name { get; set; }
    public string Category { get; set; }
    public int Stock { get; set; }
    public int Price { get; set; }

    public Product(string name, string category, int stock, int price)
    {
        Name = name;
        Category = category;
        Stock = stock;
        Price = price;
    }
}

public interface IInventory
{
    void AddProduct(IProduct product);
    void RemoveProduct(string name);
    int CalculateTotalValue();
    List<IProduct> GetProductsByCategory(string category);
    List<(string,int)> GetProductsByCategoryWithCount();
    List<IProduct> SearchProductsByName(string name);
    List<(string,List<IProduct>)> GetAllProductsByCategory();
}

public class Inventory : IInventory
{
    private List<IProduct> _products = new List<IProduct>();

    public void AddProduct(IProduct product)
    {
        _products.Add(product);
    }

    public void RemoveProduct(string name)
    {
        var item = _products.FirstOrDefault(p => p.Name == name);
        if(item != null)
            _products.Remove(item);
    }

    public int CalculateTotalValue()
    {
        return _products.Sum(p => p.Stock * p.Price);
    }

    public List<IProduct> GetProductsByCategory(string category)
    {
        return _products.Where(p => p.Category == category).ToList();
    }

    public List<(string,int)> GetProductsByCategoryWithCount()
    {
        return _products
            .GroupBy(p => p.Category)
            .Select(g => (g.Key, g.Count()))
            .OrderBy(x => x.Key)
            .ToList();
    }

    public List<IProduct> SearchProductsByName(string name)
    {
        return _products
            .Where(p => p.Name.Contains(name))
            .ToList();
    }

    public List<(string,List<IProduct>)> GetAllProductsByCategory()
    {
        return _products
            .GroupBy(p => p.Category)
            .Select(g => (g.Key, g.ToList()))
            .OrderBy(x => x.Key)
            .ToList();
    }
}

public class Solution
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        Inventory inventory = new Inventory();

        for(int i=0;i<n;i++)
        {
            var input = Console.ReadLine().Split();

            string name = input[0];
            string category = input[1];
            int stock = int.Parse(input[2]);
            int price = int.Parse(input[3]);

            Product p = new Product(name,category,stock,price);
            inventory.AddProduct(p);
        }

        var extra = Console.ReadLine().Split();
        string categorySearch = extra[0];
        string nameSearch = extra[1];
        string nameRemove = extra[2];

        Console.WriteLine(categorySearch + ":");
        foreach(var p in inventory.GetProductsByCategory(categorySearch))
        {
            Console.WriteLine($"Product Name:{p.Name} Category:{p.Category}");
        }

        Console.WriteLine(nameSearch + ":");
        foreach(var p in inventory.SearchProductsByName(nameSearch))
        {
            Console.WriteLine($"Product Name:{p.Name} Category:{p.Category}");
        }

        int total = inventory.CalculateTotalValue();
        Console.WriteLine("Total Value:$" + total);

        foreach(var c in inventory.GetProductsByCategoryWithCount())
        {
            Console.WriteLine($"{c.Item1}:{c.Item2}");
        }

        foreach(var group in inventory.GetAllProductsByCategory())
        {
            Console.WriteLine(group.Item1 + ":");
            foreach(var p in group.Item2)
            {
                Console.WriteLine($"Product Name:{p.Name} Price:{p.Price}");
            }
        }

        inventory.RemoveProduct(nameRemove);

        int newTotal = inventory.CalculateTotalValue();
        Console.WriteLine("New Total Value:$" + newTotal);
    }
}