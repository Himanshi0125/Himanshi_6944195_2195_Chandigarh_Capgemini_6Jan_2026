using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter array size: ");
        int input2 = int.Parse(Console.ReadLine());

        double output;

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
            input1[i] = int.Parse(Console.ReadLine());

            if (input1[i] < 0)
            {
                output = -1;
                Console.WriteLine("Output: " + output);
                return;
            }
        }

        int sum = 0;
        int count = 0;

        for (int i = 0; i < input2; i++)
        {
            if (input1[i] % 5 == 0)
            {
                sum += input1[i];
                count++;
            }
        }

        if (count == 0)
            output = 0;
        else
            output = (double)sum / count;

        Console.WriteLine("Output: " + output);
    }
}
