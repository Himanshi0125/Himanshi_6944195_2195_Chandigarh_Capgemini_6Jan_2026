using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter array size: ");
        int size = int.Parse(Console.ReadLine());

        int[] arr = new int[size];
        int output = 0;

        Console.WriteLine("Enter array elements:");
        for (int i = 0; i < size; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());

            if (arr[i] < 0)
            {
                output = -1;
                Console.WriteLine("Output: " + output);
                return;
            }
        }

        for (int i = 0; i < size; i++)
        {
            if (arr[i] % 3 == 0)
                output++;
        }

        Console.WriteLine("Output: " + output);
    }
}
