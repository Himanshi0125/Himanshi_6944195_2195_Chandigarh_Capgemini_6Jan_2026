using System;
namespace Day4_09Jan2026
{
    internal class MultiplyPositives
    {
        public int multiplyPositives()
        {
            int output1;

            Console.Write("Enter the size of array : ");
            int size = int.Parse(Console.ReadLine()!);
            if (size < 0)
            {
                output1 = -2;
                return output1;
            }

            int[] arr = new int[size];
            Console.WriteLine("Enter the elements of array : ");
            int ans = 1;
            for(int i = 0; i < size; i++)
            {
                arr[i] = int.Parse(Console.ReadLine()!);
                if (arr[i] > 0)
                {
                    ans *= arr[i];
                }
            }
            output1 = ans;
            return output1;
        }
    }

    class Program6
    {
        static void Main(string[] args)
        {
            MultiplyPositives obj = new MultiplyPositives();
            Console.WriteLine("Output is : " + obj.multiplyPositives());
        }
    }
}
