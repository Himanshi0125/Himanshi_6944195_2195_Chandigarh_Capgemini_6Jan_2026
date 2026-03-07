using System;

class Program
{
  static void Main()
  {
    string[] input = Console.ReadLine().Split();
    int[] arr = Array.ConvertAll(input, int.Parse);
    int d = int.Parse(Console.ReadLine());
    int count = 0;
    for (int i = 0; i < arr.Length; i++)
    {
      for (int j = i + 1; j < arr.Length; j++)
      {
        for (int k = j + 1; k < arr.Length; k++)
        {
          if ((arr[i] + arr[j] + arr[k]) % d == 0) count++;
        }
      }
    }
    Console.WriteLine(count);
  }
}
