using System;

namespace Day4_09Jan2026
{
    class SearchElement
    {
        public int searchElement()
        {
            Console.Write("Enter array size: ");
            int size = int.Parse(Console.ReadLine()!);

            if (size < 0)
            {
                return -2;
            }
            int[] arr = new int[size];
            Console.WriteLine("Enter array elements:");
            for (int i = 0; i < size; i++)
            {
                arr[i] = int.Parse(Console.ReadLine()!);
                if (arr[i] < 0)
                {
                    return -1;
                }
            }

            Console.Write("Enter element to search: ");
            int target = int.Parse(Console.ReadLine()!);

            for (int i = 0; i < size; i++)
            {
                if (arr[i] == target)
                {
                    return i;  
                }
            }

            return 1; 
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SearchElement obj = new SearchElement();
            int result = obj.searchElement();
            Console.WriteLine("Output is : " + result);
        }
    }
}
