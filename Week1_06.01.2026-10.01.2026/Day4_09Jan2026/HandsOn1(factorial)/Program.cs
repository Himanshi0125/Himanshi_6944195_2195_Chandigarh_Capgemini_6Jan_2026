//Assignment_Day4

using System;

namespace Day4_09Jan2026
{
    class Solve
    {
        public int factorialOfNum()
        {
            Console.Write("Enter the number : ");
            int num = int.Parse(Console.ReadLine()!);
            int output1 = 0;
            if (num < 0)
            {
                output1 = -1;
            }
            else if (num > 7)
            {
                output1 = -2;
            }
            else
            {
                int factorial = 1;
                for(int i = 1; i <= num; i++)
                {
                    factorial *= i;
                }
                output1 = factorial;
            }
            return output1;
        }   
    }   

    class Program{
        static void Main(string[] args)
        {
            Solve obj = new Solve();
            Console.WriteLine("The output is : " + obj.factorialOfNum());
        }
    }
}
