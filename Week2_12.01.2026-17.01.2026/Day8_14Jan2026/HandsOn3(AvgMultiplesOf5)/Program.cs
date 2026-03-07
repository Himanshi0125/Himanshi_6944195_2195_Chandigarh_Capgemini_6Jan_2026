using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter N value: ");

        int input1 = int.Parse(Console.ReadLine()!);

        double output;
        if (input1 < 0)
        {
            output = -1;
            Console.WriteLine("Output: " + output);
            return;
        }

        if (input1 > 500)
        {
            output = -2;
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

        output = (count == 0) ? 0 : (double)sum / count;
        Console.WriteLine("Output: " + output);
    }
}
