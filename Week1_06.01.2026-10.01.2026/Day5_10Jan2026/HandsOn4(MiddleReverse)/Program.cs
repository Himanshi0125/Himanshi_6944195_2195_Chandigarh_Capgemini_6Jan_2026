using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter array size: ");
        int input2 = int.Parse(Console.ReadLine()!);

        int[] output1;

        if (input2 < 0)
        {
            output1 = new int[1];
            output1[0] = -2;
            Console.WriteLine("Output: " + output1[0]);
            return;
        }

        output1 = new int[input2];
        int[] input1 = new int[input2];

        Console.WriteLine("Enter array elements:");
        for (int i = 0; i < input2; i++)
        {
            input1[i] = int.Parse(Console.ReadLine()!);

            if (input1[i] < 0)
            {
                output1[0] = -1;
                PrintArray(output1);
                return;
            }
        }

        if (input2 % 2 == 0)
        {
            output1[0] = -3;
            PrintArray(output1);
            return;
        }

        int mid = input2 / 2;

        for (int i = 0; i < mid; i++)
        {
            int temp = input1[i];
            input1[i] = input1[input2 - 1 - i];
            input1[input2 - 1 - i] = temp;
        }

        for (int i = 0; i < input2; i++)
            output1[i] = input1[i];

        PrintArray(output1);
    }

    static void PrintArray(int[] arr)
    {
        Console.Write("Output: ");
        for (int i = 0; i < arr.Length; i++)
            Console.Write(arr[i] + " ");
        Console.WriteLine();
    }
}
