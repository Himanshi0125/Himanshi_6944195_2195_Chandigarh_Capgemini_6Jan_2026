using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a positive integer: ");
        int n = int.Parse(Console.ReadLine()!);

        int root = (int)Math.Sqrt(n);

        int lowerSquare = root * root;
        int higherSquare = (root + 1) * (root + 1);

        if (n - lowerSquare <= higherSquare - n)
            Console.WriteLine(lowerSquare);
        else
            Console.WriteLine(higherSquare);
    }
}
