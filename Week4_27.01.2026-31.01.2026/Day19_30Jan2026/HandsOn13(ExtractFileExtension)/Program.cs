using System;

class UserProgramCode
{
    public static string extractExtension(string input)
    {
        int index = input.LastIndexOf('.');
        if (index == -1 || index == input.Length - 1)
            return "";

        return input.Substring(index + 1);
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter filename : ");
        string fileName = Console.ReadLine()!;
        string result = UserProgramCode.extractExtension(fileName);
        Console.WriteLine(result);
    }
}
