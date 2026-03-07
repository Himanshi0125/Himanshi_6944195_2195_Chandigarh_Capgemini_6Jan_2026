using System;
using System.Collections.Generic;
using System.Linq;

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

    Console.Write("Enter inserts as pos:substr,pos:substr,... : ");
    string? insertsInput = Console.ReadLine();
    if (insertsInput == null)
    {
      Console.WriteLine("Invalid inserts.");
      return;
    }

    List<(int pos, string substr)> inserts = new List<(int, string)>();
    string[] parts = insertsInput.Split(',', StringSplitOptions.RemoveEmptyEntries);
    foreach (string part in parts)
    {
      string[] kv = part.Split(':', 2);
      if (kv.Length == 2 && int.TryParse(kv[0], out int pos) && pos >= 0 && pos <= input.Length)
      {
        inserts.Add((pos, kv[1]));
      }
    }

    inserts = inserts.OrderByDescending(i => i.pos).ToList();
    foreach (var ins in inserts)
    {
      input = input.Insert(ins.pos, ins.substr);
    }

    Console.WriteLine("Result: " + input);
  }
}
