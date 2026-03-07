using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter size of array: ");
        int input2 = int.Parse(Console.ReadLine()!);

        int output;

        if (input2 < 0)
        {
            output = -2;
            Console.WriteLine("Output: " + output);
            return;
        }

        int[] input1 = new int[input2];

        Console.WriteLine("Enter array elements:");
        for (int i = 0; i < input2; i++)
        {
            input1[i] = int.Parse(Console.ReadLine()!);
        }

        int count = 0;

        for (int i = 0; i < input2; i++)
        {
            if (input1[i] < 0)
            {
                output = -1;
                Console.WriteLine("Output: " + output);
                return;
            }

            if (input1[i] % 3 == 0)
            {
                count++;
            }
        }

        output = count;
        Console.WriteLine("Output: " + output);
    }
}
