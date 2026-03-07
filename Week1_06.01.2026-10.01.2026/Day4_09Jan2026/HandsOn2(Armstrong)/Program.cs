using System;

namespace Day4_09Jan2026
{
    internal class ArmstrongNum
    {
        public int armstrongNum()
        {
            Console.Write("Enter a number : ");
            int num = int.Parse(Console.ReadLine()!);
            int output1 = 0;

            if (num < 0)
            {
                output1 = -1;
            }
            else if (num > 999)
            {
                output1 = -2;
            }
            else
            {
                int temp = num;
                int sum = 0;

                while (num > 0)
                {
                    int digit = num % 10;
                    sum += (digit * digit * digit);
                    num = num / 10;
                }

                if (sum == temp)
                {
                    output1 = 1;
                }
                else
                {
                    output1 = 0;
                }
            }
            return output1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ArmstrongNum obj = new ArmstrongNum();
            Console.WriteLine(obj.armstrongNum());
        }
    }
}
