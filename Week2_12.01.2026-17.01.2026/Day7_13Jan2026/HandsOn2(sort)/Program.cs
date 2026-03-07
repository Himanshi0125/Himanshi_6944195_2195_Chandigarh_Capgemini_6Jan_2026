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

        // Remove negative values
        int count = 0;
        for (int i = 0; i < size; i++)
            if (arr[i] >= 0) count++;

        int[] outputArr = new int[count];
        int index = 0;

        for (int i = 0; i < size; i++)
            if (arr[i] >= 0)
                outputArr[index++] = arr[i];

        // Sort ascending
        for (int i = 0; i < count - 1; i++)
        {
            for (int j = i + 1; j < count; j++)
            {
                if (outputArr[i] > outputArr[j])
                {
                    int temp = outputArr[i];
                    outputArr[i] = outputArr[j];
                    outputArr[j] = temp;
                }
            }
        }

        Print(outputArr);
    }

    static void Print(int[] arr)
    {
        foreach (int x in arr)
            Console.Write(x + " ");
        Console.WriteLine();
    }
}
