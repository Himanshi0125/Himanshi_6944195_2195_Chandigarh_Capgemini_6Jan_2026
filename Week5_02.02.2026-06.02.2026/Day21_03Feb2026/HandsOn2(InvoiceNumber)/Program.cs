using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.Write("Enter invoice number : ");
        string invoice = Console.ReadLine()!;
        Console.Write("Enter increament : ");
        int increment = int.Parse(Console.ReadLine()!);

        string pattern = @"CAP-(\d+)";
        Match match = Regex.Match(invoice, pattern);

        if (match.Success)
        {
            int number = int.Parse(match.Groups[1].Value);
            number += increment;
            string updatedInvoice = Regex.Replace(invoice, pattern, "CAP-" + number);
            Console.WriteLine(updatedInvoice);
        }
        else
        {
            Console.WriteLine("Invalid invoice format");
        }
    }
}
