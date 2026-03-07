using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter value of n: ");
        int n = int.Parse(Console.ReadLine()!);

        int output;

        if (n < 0 || n > 7)
        {
            output = -1;
            Console.WriteLine("Output: " + output);
            return;
        }

        int sum = 0;

        for (int i = 2; i <= n; i++)
        {
            if (IsPrime(i))
            {
                sum += i * i * i;
            }
        }

        output = sum;
        Console.WriteLine("Output: " + output);
    }

    static bool IsPrime(int num)
    {
        if (num <= 1)
            return false;

        for (int i = 2; i <= num / 2; i++)
        {
            if (num % i == 0)
                return false;
        }

        return true;
    }
}

