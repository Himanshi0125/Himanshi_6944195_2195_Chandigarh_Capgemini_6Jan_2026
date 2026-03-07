// See https://aka.ms/new-console-template for more information
using System;
using System.Text;

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

    StringBuilder left = new StringBuilder();
    StringBuilder right = new StringBuilder();

    foreach (char c in input)
    {
      if (char.IsDigit(c))
      {
        left.Append(c);
      }
      else if (char.IsLetter(c))
      {
        right.Append(c);
      }
    }

    Console.WriteLine("Left: " + left.ToString() + ", Right: " + right.ToString());
  }
}
