using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.Write("Enter string : ");
        string input1 = Console.ReadLine()!; // hi-how-are-you-Dear
        Console.Write("Enter name : ");
        string input2 = Console.ReadLine()!; // Name

        string combined = input1 + input2;

        // name should be more than 15 characters
        string pattern = @"^hi-how-are-you-Dear.{16,}$";

        if (Regex.IsMatch(combined, pattern, RegexOptions.IgnoreCase))
        {
            Console.WriteLine(input1 + " " + input2);
        }
        else
        {
            Console.WriteLine("Invalid Pattern");
        }
    }
}
