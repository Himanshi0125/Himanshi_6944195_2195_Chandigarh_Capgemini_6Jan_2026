using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter temperature in Fahrenheit: ");
        int input = int.Parse(Console.ReadLine()!);

        double output;

        if (input < 0)
        {
            output = -1;
            Console.WriteLine("Output: " + output);
            return;
        }

        output = (input - 32) * 5.0 / 9.0;

        Console.WriteLine("Celsius: " + output);
    }
}
