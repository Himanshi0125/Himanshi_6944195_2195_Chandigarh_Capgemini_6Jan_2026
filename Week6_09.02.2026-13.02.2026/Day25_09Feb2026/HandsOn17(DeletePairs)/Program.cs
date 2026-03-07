using System;
class Program
{
  static void Main(string[] args)
  {
    Console.Write("Enter the string: ");
    string? input = Console.ReadLine();
    if (input == null)
    {
      Console.WriteLine("Invalid input.");
      return;
    }

    int maxDeletions = input.Length / 2;
    Console.WriteLine("Maximum deletions: " + maxDeletions);
  }
}
