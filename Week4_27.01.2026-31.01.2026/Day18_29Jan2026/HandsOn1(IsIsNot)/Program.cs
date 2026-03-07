using System;

class UserProgramCode
{
    public static string negativeString(string input)
    {
        string[] words = input.Split(' ');
        string result = "";

        for (int i = 0; i < words.Length; i++)
        {
            // Replace only the word "is"
            if (words[i] == "is")
                result += "is not";
            else
                result += words[i];

            if (i < words.Length - 1)
                result += " ";
        }

        return result;
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter statement : ");
        string input = Console.ReadLine()!;
        string output = UserProgramCode.negativeString(input);
        Console.WriteLine(output);
    }
}
