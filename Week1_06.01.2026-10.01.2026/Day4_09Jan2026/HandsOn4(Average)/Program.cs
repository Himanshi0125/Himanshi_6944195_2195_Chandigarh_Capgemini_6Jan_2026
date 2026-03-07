using System;

namespace Day4_09Jan2026
{
    internal class AverageOfOddEven
    {
        public int averageOfOddEven()
        {
            int output1;

            Console.Write("Enter the size of array : ");
            int size = int.Parse(Console.ReadLine()!);
            if (size < 0)
            {
                output1 = -2;
            }
            int[] arr = new int[size];
            Console.WriteLine("Enter the elements of array : ");
            for(int i = 0; i < size; i++)
            {
                arr[i] = int.Parse(Console.ReadLine()!);
            }
            
            int even = 0;
            int odd = 0;
            for(int i = 0; i < size; i++)
            {
                if (i < 0)
                {
                    output1 = -1;
                    return output1;
                } 

                if (arr[i]%2 == 0)
                {
                    even += arr[i];
                }
                else
                {
                    odd += arr[i];
                }
            }
            output1 = (even+odd)/2;
            return output1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            AverageOfOddEven obj = new AverageOfOddEven();
            Console.Write("Answer is : " + obj.averageOfOddEven());
        }
    }
}
