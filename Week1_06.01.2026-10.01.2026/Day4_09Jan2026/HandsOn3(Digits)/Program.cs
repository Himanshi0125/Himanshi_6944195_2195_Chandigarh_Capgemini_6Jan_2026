using System;

namespace Day4_09Jan2026
{
    internal class NumberOfDigits
    {
        public int noOfDigits()
        {
            Console.Write("Enter a number : ");
            int num = int.Parse(Console.ReadLine()!);
            int output1;

            if (num < 0)
            {
                output1 = -1;
            }
            else
            {
                int count = 0;
                while (num > 0)
                {
                    int digit = num % 10;
                    num = num / 10;
                    count++;
                }

                output1 = count;
            }
            return output1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            NumberOfDigits obj = new NumberOfDigits();
            Console.WriteLine(obj.noOfDigits());
        }
    }
}
