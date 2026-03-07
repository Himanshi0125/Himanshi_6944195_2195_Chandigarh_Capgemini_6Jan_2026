using System;

class Program
{
  static void Main()
  {
    int N = 4;
    int T = 10;
    int current = 0;
    for (int t = 1; t < T; t++)
    {
      current = (current + 1) % N;
    }
    int from = current;
    int to = (current + 1) % N;
    Console.WriteLine($"{from} passed to {to}");
  }
}
