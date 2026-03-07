using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter array size: ");
        int input2 = int.Parse(Console.ReadLine()!);

        if (input2 < 0)
        {
            Console.WriteLine("Output: -1");
            return;
        }

        int[] input1 = new int[input2];
        Console.WriteLine("Enter array elements:");

        for (int i = 0; i < input2; i++)
        {
            input1[i] = int.Parse(Console.ReadLine()!);
        }

        // Count of non-negative numbers
        int count = 0;
        for (int i = 0; i < input2; i++)
        {
            if (input1[i] >= 0)
                count++;
        }

        // Store non-negative values
        int[] output = new int[count];
        int index = 0;
        for (int i = 0; i < input2; i++)
        {
            if (input1[i] >= 0)
            {
                output[index] = input1[i];
                index++;
            }
        }

        // Sort
        for (int i = 0; i < count - 1; i++)
        {
            for (int j = i + 1; j < count; j++)
            {
                if (output[i] > output[j])
                {
                    int temp = output[i];
                    output[i] = output[j];
                    output[j] = temp;
                }
            }
        }

        // result
        Console.Write("Output: ");
        for (int i = 0; i < count; i++)
            Console.Write(output[i] + " ");
    }
}
