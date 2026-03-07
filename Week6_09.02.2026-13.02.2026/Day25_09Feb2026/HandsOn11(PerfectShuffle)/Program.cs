// See https://aka.ms/new-console-template for more information
using System;

class Program
{
  static void Main(string[] args)
  {
    Console.Write("Enter string x: ");
    string? x = Console.ReadLine();
    if (x == null)
    {
      Console.WriteLine("Invalid input.");
      return;
    }

    Console.Write("Enter string y: ");
    string? y = Console.ReadLine();
    if (y == null)
    {
      Console.WriteLine("Invalid input.");
      return;
    }

    Console.Write("Enter string z: ");
    string? z = Console.ReadLine();
    if (z == null)
    {
      Console.WriteLine("Invalid input.");
      return;
    }

    bool isShuffle = IsPerfectShuffle(x, y, z);
    Console.WriteLine(isShuffle ? "true" : "false");
  }

  static bool IsPerfectShuffle(string x, string y, string z)
  {
    if (x.Length + y.Length != z.Length)
    {
      return false;
    }

    int i = 0, j = 0, k = 0;
    while (k < z.Length)
    {
      if (i < x.Length && z[k] == x[i])
      {
        i++;
        k++;
      }
      else if (j < y.Length && z[k] == y[j])
      {
        j++;
        k++;
      }
      else
      {
        return false;
      }
    }
    return i == x.Length && j == y.Length;
  }
}
