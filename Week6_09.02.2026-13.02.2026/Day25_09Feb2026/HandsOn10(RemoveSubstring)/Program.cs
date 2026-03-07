// See https://aka.ms/new-console-template for more information
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

    Console.Write("Enter the position: ");
    string? posInput = Console.ReadLine();
    if (!int.TryParse(posInput, out int position) || position < 0 || position >= input.Length)
    {
      Console.WriteLine("Invalid position.");
      return;
    }

    Console.Write("Enter the substring to remove: ");
    string? toRemove = Console.ReadLine();
    if (toRemove == null || position + toRemove.Length > input.Length || input.Substring(position, toRemove.Length) != toRemove)
    {
      Console.WriteLine("Invalid substring or position.");
      return;
    }

    Console.Write("Enter the substring to insert: ");
    string? toInsert = Console.ReadLine();
    if (toInsert == null)
    {
      Console.WriteLine("Invalid substring.");
      return;
    }

    string result = input.Remove(position, toRemove.Length).Insert(position, toInsert);
    Console.WriteLine("Result: " + result);
  }
}
