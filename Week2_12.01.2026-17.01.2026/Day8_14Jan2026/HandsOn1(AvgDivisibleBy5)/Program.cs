using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter limit: ");
        int input1 = int.Parse(Console.ReadLine()!);

        double output;

        // Business Rule
        if (input1 < 0)
        {
            output = -1;
            Console.WriteLine("Output: " + output);
            return;
        }

        int sum = 0;
        int count = 0;

        for (int i = 1; i <= input1; i++)
        {
            if (i % 5 == 0)
            {
                sum += i;
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
