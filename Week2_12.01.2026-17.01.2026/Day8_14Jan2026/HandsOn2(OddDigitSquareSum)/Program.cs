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

        int sum = 0;
        int num = input1;

        while (num > 0)
        {
            int digit = num % 10;

            if (digit % 2 != 0)
            {
                sum += digit * digit;
            }

            num /= 10;
        }

        output = sum;
        Console.WriteLine("Output: " + output);
    }
}
