using System;

namespace Day3_08Jan2026
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for(int i = 5; i >= 0; i--)
            {
                for(int j = 0; j <= i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
