using System;
using System.Linq;

class Program
{
  static void Main()
  {
    int[] skills = Console.ReadLine().Split().Select(int.Parse).ToArray();
    int[] teamSizes = Console.ReadLine().Split().Select(int.Parse).ToArray();
    Array.Sort(skills);
    Array.Reverse(skills);
    int index = 0;
    long total = 0;
    foreach (int size in teamSizes)
    {
      int min = int.MaxValue;
      int max = int.MinValue;
      for (int i = 0; i < size; i++)
      {
        int skill = skills[index++];
        min = Math.Min(min, skill);
        max = Math.Max(max, skill);
      }
      total += min + max;
    }
    Console.WriteLine(total);
  }
}
