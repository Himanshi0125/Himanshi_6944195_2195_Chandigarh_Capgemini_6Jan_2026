using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a positive integer: ");
        string input = Console.ReadLine()!;

        int sum = 0;

        foreach (char ch in input)
        {
            sum += ch - '0';
        }

        Console.WriteLine(sum);
    }
}
