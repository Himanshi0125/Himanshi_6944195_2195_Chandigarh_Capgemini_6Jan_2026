// input 3 numbers and find the greatest

using System;

namespace Day3_08Jan2026
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x, y, z;
            Console.Write("Enter x: "); 
            x = int.Parse(Console.ReadLine()!);
            Console.Write("Enter y: "); 
            y = int.Parse(Console.ReadLine()!);
            Console.Write("Enter z: "); 
            z = int.Parse(Console.ReadLine()!);

            if (x >= y && x >= z)
                Console.WriteLine("x is greatest");
            else if (y >= x && y >= z)
                Console.WriteLine("y is greatest");
            else
                Console.WriteLine("z is greatest");
            Console.ReadLine();
        }
    }
}
