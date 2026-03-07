using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter amount in rupees: ");
        int input = int.Parse(Console.ReadLine());

        int output;

        if (input < 0)
        {
            output = -1;
            Console.WriteLine("Output: " + output);
            return;
        }

        int amount = input;
        int count = 0;

        int notes;

        notes = amount / 500;
        count += notes;
        amount %= 500;

        notes = amount / 100;
        count += notes;
        amount %= 100;

        notes = amount / 50;
        count += notes;
        amount %= 50;

        notes = amount / 10;
        count += notes;
        amount %= 10;

        notes = amount / 1;
        count += notes;

        output = count;
        Console.WriteLine("Output: " + output);
    }
}
