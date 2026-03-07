using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter number: ");
        int input1 = int.Parse(Console.ReadLine()!);

        long output;

        if (input1 < 0)
        {
            output = -1;
            Console.WriteLine("Output: " + output);
            return;
        }

        if (input1 > 32767)
        {
            output = -2;
            Console.WriteLine("Output: " + output);
            return;
        }

        long sum = 0;

        for (int i = 2; i <= input1; i++)
        {
            if (IsPrime(i))
                sum += (long)i * i * i;
        }

        output = sum;
        Console.WriteLine("Output: " + output);
    }

    static bool IsPrime(int n)
    {
        if (n <= 1)
            return false;

        for (int i = 2; i * i <= n; i++)
            if (n % i == 0)
                return false;

        return true;
    }
}
