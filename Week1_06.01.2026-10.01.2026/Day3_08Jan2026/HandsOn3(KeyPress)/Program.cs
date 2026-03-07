using System;

namespace Day3_08Jan2026
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number : ");
            string num = Console.ReadLine();

            if (num.Length > 1)
            {
                Console.WriteLine("Invalid Number");
                return;
            }
            if (char.IsDigit(num[0]))
            {
                Console.WriteLine("Your number is : " + num);
            }
            else
            {
                Console.WriteLine("Invalid Number");
            }
        
            Console.ReadLine();
        }
    }
}

