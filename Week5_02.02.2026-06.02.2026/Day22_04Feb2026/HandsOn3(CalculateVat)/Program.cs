using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter product code : ");
        char product = char.Parse(Console.ReadLine()!);
        Console.Write("Enter price : ");
        int price = int.Parse(Console.ReadLine()!);

        double vat = 0;

        switch (product)
        {
            case 'M':
                vat = 5;
                break;
            case 'V':
                vat = 12;
                break;
            case 'C':
                vat = 6.25;
                break;
            case 'D':
                vat = 6;
                break;
            default:
                Console.WriteLine("Invalid product");
                return;
        }

        double vatAmount = price * vat / 100;
        Console.WriteLine(vatAmount);
    }
}
