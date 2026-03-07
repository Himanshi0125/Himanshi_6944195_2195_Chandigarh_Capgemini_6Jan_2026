using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter array size: ");
        int input3 = int.Parse(Console.ReadLine()!);

        int[] output;

        if (input3 < 0)
        {
            output = new int[1];
            output[0] = -2;
            Console.WriteLine("Output: " + output[0]);
            return;
        }

        int[] input1 = new int[input3];
        int[] input2 = new int[input3];
        output = new int[input3];

        Console.WriteLine("Enter elements of first array:");
        for (int i = 0; i < input3; i++)
        {
            input1[i] = int.Parse(Console.ReadLine()!);
            if (input1[i] < 0)
            {
                output[0] = -1;
                Print(output);
                return;
            }
        }

        Console.WriteLine("Enter elements of second array:");
        for (int i = 0; i < input3; i++)
        {
            input2[i] = int.Parse(Console.ReadLine()!);
            if (input2[i] < 0)
            {
                output[0] = -1;
                Print(output);
                return;
            }
        }

        for (int i = 0; i < input3; i++)
        {
            output[i] = input1[i] + input2[input3 - 1 - i];
        }

        Print(output);
    }

    static void Print(int[] arr)
    {
        Console.Write("Output: ");
        for (int i = 0; i < arr.Length; i++)
            Console.Write(arr[i] + " ");
        Console.WriteLine();
    }
}
