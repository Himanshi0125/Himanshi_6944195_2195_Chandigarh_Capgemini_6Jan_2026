using System;
using System.Linq;

class Program
{
  static void Main()
  {
    Console.Write("Enter the first list of integers (comma-separated): ");
    string first = Console.ReadLine();
    Console.Write("Enter the second list of integers (comma-separated): ");
    string second = Console.ReadLine();

    var list1 = first.Split(',').Select(int.Parse).ToList();
    var list2 = second.Split(',').Select(int.Parse).ToList();

    foreach (var n in list1)
    {
      int sum = list2.Where(x => x == n).Sum();
      Console.WriteLine($"{n}-{sum}");
    }
  }
}
