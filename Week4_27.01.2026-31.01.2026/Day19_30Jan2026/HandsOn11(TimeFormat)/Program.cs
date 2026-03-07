using System;
using System.Text.RegularExpressions;

class UserProgramCode
{
    public static int validateTime(string input)
    {
        string pattern = @"^(0?[1-9]|1[0-2]):[0-5][0-9]\s(am|pm)$";
        return Regex.IsMatch(input.ToLower(), pattern) ? 1 : -1;
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter time : ");
        string time = Console.ReadLine()!;
        int result = UserProgramCode.validateTime(time);
        Console.WriteLine(result);
    }
}
