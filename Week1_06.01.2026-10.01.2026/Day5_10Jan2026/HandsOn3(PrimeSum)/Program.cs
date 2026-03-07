using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter size of array: ");
        int input2 = int.Parse(Console.ReadLine()!);

        int output1;

        if (input2 < 0)
        {
            output1 = -2;
            Console.WriteLine("Output: " + output1);
            return;
        }

        int[] input1 = new int[input2];

        Console.WriteLine("Enter array elements:");
        for (int i = 0; i < input2; i++)
        {
            input1[i] = int.Parse(Console.ReadLine()!);

            if (input1[i] < 0)
            {
                output1 = -1;
                Console.WriteLine("Output: " + output1);
                return;
            }
        }

        int sum = 0;
        int primeCount = 0;

        for (int i = 0; i < input2; i++)
        {
            if (IsPrime(input1[i]))
            {
                sum += input1[i];
                primeCount++;
            }
        }

        if (primeCount == 0)
            output1 = -3;
        else
            output1 = sum;

        Console.WriteLine("Output: " + output1);
    }

    static bool IsPrime(int n)
    {
        if (n <= 1)
            return false;

        for (int i = 2; i <= n / 2; i++)
        {
            if (n % i == 0)
                return false;
        }

        return true;
    }
}
