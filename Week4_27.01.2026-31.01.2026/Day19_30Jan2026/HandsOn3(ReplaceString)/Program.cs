using System;
using System.Transactions;

class UserProgramCode
{
    public static string replaceString(string input1, int input2, char input3)
    {
        foreach (char c in input1)
            if (!char.IsLetter(c) && c != ' ')
                return "-1";

        if (input2 <= 0)
            return "-2";

        if (char.IsLetterOrDigit(input3))
            return "-3";

        string[] words = input1.Split(' ');
        if (input2 > words.Length)
            return input1.ToLower();

        words[input2 - 1] = new string(input3, words[input2 - 1].Length);
        return string.Join(" ", words).ToLower();
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter string : ");
        string s = Console.ReadLine()!;
        Console.Write("Enter nth value : ");
        int n = int.Parse(Console.ReadLine()!);
        Console.Write("Enter character : ");
        char ch = char.Parse(Console.ReadLine()!);

        string result = UserProgramCode.replaceString(s, n, ch);

        if (result == "-1")
            Console.WriteLine("Invalid String");
        else if (result == "-2")
            Console.WriteLine("Number not positive");
        else if (result == "-3")
            Console.WriteLine("Character not a special character");
        else
            Console.WriteLine(result);
    }
}
