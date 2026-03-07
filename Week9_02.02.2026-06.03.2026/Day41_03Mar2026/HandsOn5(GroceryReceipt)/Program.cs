using System;
using System.Collections.Generic;
using System.Linq;

public class GroceryReceiptBase
{
    public Dictionary<string, int> Prices;
    public Dictionary<string, int> Discounts;

    public GroceryReceiptBase(Dictionary<string, int> prices, Dictionary<string, int> discounts)
    {
        Prices = prices;
        Discounts = discounts;
    }

    public virtual List<(string, int, double)> GenerateReceipt(List<string> items)
    {
        return new List<(string, int, double)>();
    }
}

public class GroceryReceipt : GroceryReceiptBase
{
    public GroceryReceipt(Dictionary<string, int> prices, Dictionary<string, int> discounts)
        : base(prices, discounts)
    {
    }

    public override List<(string, int, double)> GenerateReceipt(List<string> items)
    {
        var result = new List<(string, int, double)>();

        var grouped = items.GroupBy(x => x);

        foreach (var g in grouped)
        {
            string item = g.Key;
            int quantity = g.Count();

            int price = Prices[item];
            int discount = Discounts.ContainsKey(item) ? Discounts[item] : 0;

            double total = quantity * price * (1 - discount / 100.0);

            result.Add((item, price, total));
        }

        return result.OrderBy(x => x.Item1).ToList();
    }
}

class Solution
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Dictionary<string, int> prices = new Dictionary<string, int>();

        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split();
            prices[input[0]] = int.Parse(input[1]);
        }

        int m = int.Parse(Console.ReadLine());
        Dictionary<string, int> discounts = new Dictionary<string, int>();

        for (int i = 0; i < m; i++)
        {
            var input = Console.ReadLine().Split();
            discounts[input[0]] = int.Parse(input[1]);
        }

        int k = int.Parse(Console.ReadLine());
        List<string> items = new List<string>();

        for (int i = 0; i < k; i++)
        {
            items.Add(Console.ReadLine());
        }

        GroceryReceipt receipt = new GroceryReceipt(prices, discounts);

        var result = receipt.GenerateReceipt(items);

        foreach (var r in result)
        {
            Console.WriteLine($"{r.Item1} {r.Item2} {r.Item3:F2}");
        }
    }
}