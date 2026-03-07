using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int input1 = int.Parse(Console.ReadLine()!);

        int output;

        if (input1 < 0)
        {
            output = -1;
            Console.WriteLine("Output: " + output);
            return;
        }

        if (input1 % 3 == 0 || input1 % 5 == 0)
        {
            output = -2;
            Console.WriteLine("Output: " + output);
            return;
        }

        int num = input1;
        int product = 1;

        while (num > 0)
        {
            int digit = num % 10;
            product *= digit;
            num = num / 10;
        }

        if (product % 3 == 0 || product % 5 == 0)
            output = 1;
        else
            output = 0;

        Console.WriteLine("Output: " + output);
    }
}
