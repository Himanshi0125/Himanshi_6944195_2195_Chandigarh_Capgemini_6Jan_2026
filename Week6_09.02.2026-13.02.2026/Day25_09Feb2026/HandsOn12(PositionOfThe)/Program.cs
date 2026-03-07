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

    for (int i = 0; i < n; i++)
    {
      Console.Write("Enter line " + (i + 1) + ": ");
      string? line = Console.ReadLine();
      if (line == null)
      {
        Console.WriteLine("Invalid line.");
        continue;
      }

      int posThe = line.IndexOf("the");
      int posOf = line.IndexOf("of");
      Console.WriteLine("the: " + (posThe == -1 ? "-1" : posThe.ToString()) + ", of: " + (posOf == -1 ? "-1" : posOf.ToString()));
    }
  }
}
