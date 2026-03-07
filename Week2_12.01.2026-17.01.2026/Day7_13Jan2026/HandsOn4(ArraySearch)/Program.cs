using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter array size: ");
        int size = int.Parse(Console.ReadLine()!);

        int output;

        if (size < 0)
        {
            output = -2;
            Console.WriteLine("Output: " + output);
            return;
        }

        int[] arr = new int[size];

        Console.WriteLine("Enter array elements:");
        for (int i = 0; i < size; i++)
            arr[i] = int.Parse(Console.ReadLine()!);

        for (int i = 0; i < size; i++)
        {
            if (arr[i] < 0)
            {
                output = -1;
                Console.WriteLine("Output: " + output);
                return;
            }
        }

        Console.Write("Enter element to search: ");
        int key = int.Parse(Console.ReadLine()!);

        bool found = false;

        for (int i = 0; i < size; i++)
        {
            if (arr[i] == key)
            {
                found = true;
                break;
            }
        }

        if (found)
            output = 1;
        else
            output = -3;

        Console.WriteLine("Output: " + output);
    }
}
