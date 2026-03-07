using System;
class Program
{
    static void Main()
    {
        Console.Write("Enter the number of dealerships : ");
        int n = int.Parse(Console.ReadLine()!);

        for(int i = 0; i < n; i++)
        {
            Console.Write("Enter number of bikes : ");
            int bikes = int.Parse(Console.ReadLine()!);
            Console.Write("Enter number of cars : ");
            int cars = int.Parse(Console.ReadLine()!);

            int tyres = (bikes * 2) + (cars * 4);
            Console.WriteLine(tyres);
        }
    }
}