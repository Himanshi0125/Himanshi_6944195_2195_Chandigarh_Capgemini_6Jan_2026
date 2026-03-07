using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter value of n: ");
        int n = int.Parse(Console.ReadLine());

        long output;

        if (n < 0)
        {
            output = -1;
            Console.WriteLine("Output: " + output);
            return;
        }
        if (n > 32676)
        {
            output = -2;
            Console.WriteLine("Output: " + output);
            return;
        }

        long sum = 0;
        for (int i = 2; i <= n; i++)
        {
            if (IsPrime(i))
            {
                sum += (long)i * i * i;
            }
        }

        output = sum;
        Console.WriteLine("Output: " + output);
    }

    static bool IsPrime(int num)
    {
        if (num <= 1)
            return false;

        for (int i = 2; i * i <= num; i++)
        {
            if (num % i == 0)
                return false;
        }

        return true;
    }
}
