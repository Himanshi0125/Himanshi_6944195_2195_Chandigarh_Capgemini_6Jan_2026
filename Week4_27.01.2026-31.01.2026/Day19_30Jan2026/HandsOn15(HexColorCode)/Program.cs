using System;
using System.Text.RegularExpressions;

class UserProgramCode
{
    public static int validateHexColor(string input)
    {
        string pattern = @"^#[0-9A-Fa-f]{6}$";

        if (Regex.IsMatch(input, pattern))
            return 1;

        return -1;
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter Hex Color Code : ");
        string colorCode = Console.ReadLine()!;
        int result = UserProgramCode.validateHexColor(colorCode);
        Console.WriteLine(result);
    }
}
