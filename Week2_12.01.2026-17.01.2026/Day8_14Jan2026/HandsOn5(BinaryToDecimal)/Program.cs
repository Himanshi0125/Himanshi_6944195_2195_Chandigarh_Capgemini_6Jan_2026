using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter binary number: ");
        string input1 = Console.ReadLine()!;

        int output;

        if (int.Parse(input1) > 11111)
        {
            output = -2;
            Console.WriteLine("Output: " + output);
            return;
        }

        for (int i = 0; i < input1.Length; i++)
        {
            if (input1[i] != '0' && input1[i] != '1')
            {
                output = -1;
                Console.WriteLine("Output: " + output);
                return;
            }
        }

        int decimalValue = 0;
        int power = 1;

        for (int i = input1.Length - 1; i >= 0; i--)
        {
            if (input1[i] == '1')
                decimalValue += power;

            power *= 2;
        }

        output = decimalValue;
        Console.WriteLine("Output: " + output);
    }
}
