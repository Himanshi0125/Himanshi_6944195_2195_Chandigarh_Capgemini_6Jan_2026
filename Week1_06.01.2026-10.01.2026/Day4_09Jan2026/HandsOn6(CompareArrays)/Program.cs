using System;

namespace Day4_09Jan2026
{
    internal class CompareArrays
    {
        public int[] CompareArraysMethod()
        {
            int[] a = { 9, 3, 8, 4 };
            int[] b = { 6, 7, 1, 4 };

            int[] output = new int[a.Length];

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] < 0 || b[i] < 0)
                {
                    return new int[] { -1 };
                }

                output[i] = Math.Max(a[i], b[i]);
            }

            return output;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CompareArrays obj = new CompareArrays();
            int[] result = obj.CompareArraysMethod();

            Console.Write("Output is: ");
            foreach (int val in result)
            {
                Console.Write(val + " ");
            }
        }
    }
}
