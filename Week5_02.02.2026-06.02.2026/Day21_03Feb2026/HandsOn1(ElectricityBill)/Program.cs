using System;


class Program
{
    static void Main()
    {
        Console.Write("Enter reading 1 : ");
        string input1 = Console.ReadLine()!;
        Console.Write("Enter reading 2 : ");
        string input2 = Console.ReadLine()!;
        Console.Write("Enter rate per unit : ");
        int rate = int.Parse(Console.ReadLine()!);

        string read1 = "";
        foreach (char ch in input1)
        {
            if (Char.IsDigit(ch))
            {
                read1 += ch;
            }
        }

        string read2 = "";
        foreach (char ch in input2)
        {
            if (Char.IsDigit(ch))
            {
                read2 += ch;
            }
        }

        int reading1 = Int32.Parse(read1);
        int reading2 = Int32.Parse(read2);

        int billAmount = (reading2 - reading1) * rate;
        Console.WriteLine("Bill Amount = " + billAmount);
        
    }
}
