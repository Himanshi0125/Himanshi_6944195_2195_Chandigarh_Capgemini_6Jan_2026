using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string password = Console.ReadLine()!;

        string pattern = @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";

        if (Regex.IsMatch(password, pattern))
            Console.WriteLine("Strong");
        else
            Console.WriteLine("Weak");
    }
}
