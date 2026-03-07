using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.Write("Enter invoice number : ");
        string invoice = Console.ReadLine()!;
        Console.Write("Enter new location : ");
        string location = Console.ReadLine()!;

        string pattern = @"CAP-([A-Z]+)-(\d+)";
        Match match = Regex.Match(invoice, pattern);

        if (match.Success)
        {
            string newInvoice = Regex.Replace(invoice, pattern, "CAP-" + location + "-$2");
            Console.WriteLine("New Invoice is : " + newInvoice);
        }
        else
        {
            Console.WriteLine("Invalid invoice format");
        }
    }
}
