using System;
using System.Collections.Generic;
using System.Linq;

public interface IProduct
{
    int Id { get; set; }
    string Name { get; set; }
    decimal Price { get; set; }
}

public interface ICategory
{
    int Id { get; set; }
    string Name { get; set; }
    List<IProduct> Products { get; set; }
    void AddProduct(IProduct product);
}

public interface ICompany
{
    int Id { get; set; }
    string Name { get; set; }
    List<ICategory> Categories { get; set; }

    void AddCategory(ICategory category);
    string GetTopCategoryNameByProductCount();
    List<IProduct> GetProductsBelongsToMultipleCategory();
    (string, decimal) GetTopCategoryBySumOfProductPrices();
    List<(string, decimal)> GetCategoriesWithSumOfTheProductPrices();
}

public class Product : IProduct
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }

    public Product(int id, string name, decimal price)
    {
        Id = id;
        Name = name;
        Price = price;
    }
}

public class Category : ICategory
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<IProduct> Products { get; set; }

    public Category(int id, string name)
    {
        Id = id;
        Name = name;
        Products = new List<IProduct>();
    }

    public void AddProduct(IProduct product)
    {
        Products.Add(product);
    }
}

public class Company : ICompany
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<ICategory> Categories { get; set; }

    public Company(int id, string name)
    {
        Id = id;
        Name = name;
        Categories = new List<ICategory>();
    }

    public void AddCategory(ICategory category)
    {
        Categories.Add(category);
    }

    public string GetTopCategoryNameByProductCount()
    {
        return Categories
            .OrderByDescending(c => c.Products.Count)
            .First().Name;
    }

    public List<IProduct> GetProductsBelongsToMultipleCategory()
    {
        return Categories
            .SelectMany(c => c.Products)
            .GroupBy(p => p.Id)
            .Where(g => g.Select(p => p.Id).Count() > 1)
            .Select(g => g.First())
            .ToList();
    }

    public (string, decimal) GetTopCategoryBySumOfProductPrices()
    {
        var result = Categories
            .Select(c => (Name: c.Name, Sum: c.Products.Sum(p => p.Price)))
            .OrderByDescending(x => x.Sum)
            .First();

        return result;
    }

    public List<(string, decimal)> GetCategoriesWithSumOfTheProductPrices()
    {
        return Categories
            .Select(c => (c.Name, c.Products.Sum(p => p.Price)))
            .ToList();
    }
}

class Solution
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        Dictionary<int, IProduct> products = new Dictionary<int, IProduct>();

        for (int i = 0; i < n; i++)
        {
            var parts = Console.ReadLine().Split();
            int id = int.Parse(parts[0]);
            string name = parts[1];
            decimal price = decimal.Parse(parts[2]);

            products[id] = new Product(id, name, price);
        }

        int m = int.Parse(Console.ReadLine());
        Dictionary<int, ICategory> categories = new Dictionary<int, ICategory>();

        for (int i = 0; i < m; i++)
        {
            var parts = Console.ReadLine().Split();
            int id = int.Parse(parts[0]);
            string name = parts[1];

            categories[id] = new Category(id, name);
        }

        Company company = new Company(1, "Ecommerce");

        foreach (var c in categories.Values)
            company.AddCategory(c);

        int k = int.Parse(Console.ReadLine());

        for (int i = 0; i < k; i++)
        {
            var parts = Console.ReadLine().Split(',');

            int categoryId = int.Parse(parts[0]);
            int productId = int.Parse(parts[1]);

            categories[categoryId].AddProduct(products[productId]);
        }

        Console.WriteLine("Top category:" + company.GetTopCategoryNameByProductCount());

        Console.WriteLine("Common products:");
        foreach (var p in company.GetProductsBelongsToMultipleCategory())
            Console.WriteLine(p.Name);

        var top = company.GetTopCategoryBySumOfProductPrices();
        Console.WriteLine("Most valuable category:" + top.Item1 + " " + top.Item2);

        foreach (var c in company.GetCategoriesWithSumOfTheProductPrices())
            Console.WriteLine(c.Item1 + " " + c.Item2);
    }
}