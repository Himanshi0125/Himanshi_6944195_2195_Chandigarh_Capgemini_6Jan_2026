using System;
namespace Day4_09Jan2026
{
    internal class SumEvens
    {
        public int sumEvens()
        {
            int output1;
            int sum = 0;

            Console.Write("Enter the number : ");
            int num = int.Parse(Console.ReadLine()!);
            if (num < 0)
            {
                output1 = -1;
                return output1;
            }
            else if (num > 32767)
            {
                output1 = -2;
                return output1;
            }
            else
            {
                while(num > 0)
                {
                    int digit = num % 10;
                    if (digit % 2 == 0)
                    {
                        sum += digit;
                    }
                    num = num / 10;
                }
                output1 = sum;
            }

            return output1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SumEvens obj = new SumEvens();
            Console.WriteLine("Output is : " + obj.sumEvens());
        }
    }
}
