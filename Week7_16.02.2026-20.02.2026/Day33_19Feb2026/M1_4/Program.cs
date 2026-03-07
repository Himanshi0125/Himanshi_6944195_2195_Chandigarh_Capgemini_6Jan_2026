using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the value of a : ");
        int a = int.Parse(Console.ReadLine()!);
        Console.WriteLine("Enter the value of b : ");
        int b = int.Parse(Console.ReadLine()!);

        int result = (a*a*a) + (a*a*b) + (4*a*b) + (2*a*b*b) + (a*b*b) + (b*b*b);

        Console.WriteLine("Evaluated answer : "+ result);
    }
}