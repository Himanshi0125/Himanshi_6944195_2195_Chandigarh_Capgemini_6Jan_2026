using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int input = int.Parse(Console.ReadLine()!);

        int output;

        if (input < 0)
        {
            output = -2;
            Console.WriteLine("Output: " + output);
            return;
        }

        int sum = 0;

        for (int i = 1; i <= input / 2; i++)
        {
            if (input % i == 0)
                sum += i;
        }

        if (sum == input)
            output = 1;
        else
            output = -1;

        Console.WriteLine("Output: " + output);
    }
}
