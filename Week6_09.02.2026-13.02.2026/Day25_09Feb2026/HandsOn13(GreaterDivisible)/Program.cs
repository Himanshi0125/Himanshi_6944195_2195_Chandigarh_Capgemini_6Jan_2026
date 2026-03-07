using System;

class Program
{
  static void Main(string[] args)
  {
    Console.Write("Enter N: ");
    string? nInput = Console.ReadLine();
    if (!int.TryParse(nInput, out int n) || n <= 0)
    {
      Console.WriteLine("Invalid N.");
      return;
    }

    Console.Write("Enter array elements separated by spaces: ");
    string? input = Console.ReadLine();
    if (input == null)
    {
      Console.WriteLine("Invalid input.");
      return;
    }

    string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    if (parts.Length != n)
    {
      Console.WriteLine("Array must have N elements.");
      return;
    }

    int[] arr = new int[n];
    for (int i = 0; i < n; i++)
    {
      if (!int.TryParse(parts[i], out arr[i]) || arr[i] <= 0)
      {
        Console.WriteLine("Invalid array element.");
        return;
      }
    }

    int count = 0;
    for (int i = 0; i < n; i++)
    {
      for (int j = i + 1; j < n; j++)
      {
        if (arr[j] > arr[i] && arr[j] % arr[i] == 0)
        {
          count++;
        }
      }
    }

    Console.WriteLine("Count: " + count);
  }
}
