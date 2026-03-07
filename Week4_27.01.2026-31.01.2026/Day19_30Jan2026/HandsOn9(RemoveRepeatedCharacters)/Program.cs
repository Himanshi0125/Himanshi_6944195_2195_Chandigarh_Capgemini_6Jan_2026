using System;
using System.Text;

class UserProgramCode
{
    public static string removeRepeatedCharacters(string input1)
    {
        StringBuilder sb = new StringBuilder();

        foreach (char c in input1)
        {
            if (sb.ToString().IndexOf(c) == -1)
                sb.Append(c);
        }
        return sb.ToString();
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter string : ");
        string input = Console.ReadLine()!;
        string result = UserProgramCode.removeRepeatedCharacters(input);
        Console.WriteLine(result);
    }
}
