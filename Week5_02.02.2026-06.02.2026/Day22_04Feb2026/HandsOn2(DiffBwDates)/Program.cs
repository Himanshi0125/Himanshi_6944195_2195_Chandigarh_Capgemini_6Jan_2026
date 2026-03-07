using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter Start Date : ");
        string input1 = Console.ReadLine()!; // 12/02/2014
        Console.Write("Enter End Date : ");
        string input2 = Console.ReadLine()!; // 27/02/2014

        DateTime date1 = DateTime.ParseExact(input1, "dd/MM/yyyy", null);
        DateTime date2 = DateTime.ParseExact(input2, "dd/MM/yyyy", null);

        int days = (date2 - date1).Days;

        Console.WriteLine(days + " days");
    }
}
