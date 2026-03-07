using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter array size: ");
        int input2 = int.Parse(Console.ReadLine()!);

        int[] output;

        if (input2 < 0)
        {
            output = new int[1];
            output[0] = -2;
            Console.WriteLine("Output: " + output[0]);
            return;
        }

        int[] input1 = new int[input2];
        output = new int[input2];  

        Console.WriteLine("Enter array elements:");
        for (int i = 0; i < input2; i++)
        {
            input1[i] = int.Parse(Console.ReadLine()!);

            if (input1[i] < 0)
            {
                output[0] = -1;
                Print(output, 1);
                return;
            }
        }

        int outIndex = 0;

        for (int i = 0; i < input2; i++)
        {
            bool isDuplicate = false;

            for (int j = 0; j < outIndex; j++)
            {
                if (input1[i] == output[j])
                {
                    isDuplicate = true;
                    break;
                }
            }

            if (!isDuplicate)
            {
                output[outIndex] = input1[i];
                outIndex++;
            }
        }

        Print(output, outIndex);
    }

    static void Print(int[] arr, int size)
    {
        Console.Write("Output: ");
        for (int i = 0; i < size; i++)
            Console.Write(arr[i] + " ");
        Console.WriteLine();
    }
}
