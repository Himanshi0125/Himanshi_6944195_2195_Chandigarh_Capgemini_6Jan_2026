using System;
using System.Linq;

class Program
{
  static void Main()
  {
    Console.Write("Enter array (comma-separated): ");
    var arr = Console.ReadLine().Split(',').Select(int.Parse).ToArray();
    int score = 0;
    for (int i = 0; i < arr.Length - 1; i++)
    {
      if ((arr[i] + arr[i + 1]) % 2 == 0) score += 5;
    }
    for (int i = 0; i < arr.Length - 2; i++)
    {
      long sum = arr[i] + arr[i + 1] + arr[i + 2];
      long prod = (long)arr[i] * arr[i + 1] * arr[i + 2];
      if (sum % 2 == 1 && prod % 2 == 0) score += 10;
    }
    Console.WriteLine(score);
  }
}
