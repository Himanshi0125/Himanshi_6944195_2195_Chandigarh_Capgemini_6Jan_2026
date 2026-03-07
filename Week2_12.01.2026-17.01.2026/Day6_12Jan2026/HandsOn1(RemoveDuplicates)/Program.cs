using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter array size: ");
        int size = int.Parse(Console.ReadLine());

        int[] input = new int[size];
        int[] output = new int[size];  

        Console.WriteLine("Enter array elements:");
        for (int i = 0; i < size; i++)
        {
            input[i] = int.Parse(Console.ReadLine());

            if (input[i] < 0)
            {
                output[0] = -1;
                Print(output, 1);
                return;
            }
        }

        int outIndex = 0;

        for (int i = 0; i < size; i++)
        {
            bool isDuplicate = false;

            for (int j = 0; j < outIndex; j++)
            {
                if (input[i] == output[j])
                {
                    isDuplicate = true;
                    break;
                }
            }

            if (!isDuplicate)
            {
                output[outIndex] = input[i];
                outIndex++;
            }
        }

        Print(output, outIndex);
    }

    static void Print(int[] arr, int length)
    {
        Console.Write("Output: ");
        for (int i = 0; i < length; i++)
            Console.Write(arr[i] + " ");
        Console.WriteLine();
    }
}
