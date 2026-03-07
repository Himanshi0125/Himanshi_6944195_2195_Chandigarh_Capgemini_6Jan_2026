using System;
class Program
{
    static void Main()
    {
        Console.Write("Enter array size: ");
        int size = int.Parse(Console.ReadLine()!);

        if (size < 0)
        {
            int[] output = { -1 };
            Print(output);
            return;
        }

        int[] arr = new int[size];

        Console.WriteLine("Enter array elements:");
        for (int i = 0; i < size; i++)
            arr[i] = int.Parse(Console.ReadLine()!);

        int mid = size / 2;

        // Sort first half ascending
        for (int i = 0; i < mid - 1; i++)
        {
            for (int j = i + 1; j < mid; j++)
            {
                if (arr[i] > arr[j])
                {
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }
        }

        // Sort second half descending
        for (int i = mid; i < size - 1; i++)
        {
            for (int j = i + 1; j < size; j++)
            {
                if (arr[i] < arr[j])
                {
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }
        }

        Print(arr);
    }

    static void Print(int[] arr)
    {
        foreach (int x in arr)
            Console.Write(x + " ");
        Console.WriteLine();
    }
}
