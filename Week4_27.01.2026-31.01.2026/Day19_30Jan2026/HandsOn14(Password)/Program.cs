using System;

class UserProgramCode
{
    public static int validatePassword(string input)
    {
        if (input.Length < 8)
            return -1;

        if (!char.IsLetter(input[0]))
            return -1;

        if (!char.IsLetterOrDigit(input[input.Length - 1]))
            return -1;

        bool hasSpecial = false;
        bool hasLetter = false;
        bool hasDigit = false;

        foreach (char c in input)
        {
            if (c == '@' || c == '#' || c == '_')
                hasSpecial = true;
            else if (char.IsLetter(c))
                hasLetter = true;
            else if (char.IsDigit(c))
                hasDigit = true;
        }

        if (hasSpecial && hasLetter && hasDigit)
            return 1;

        return -1;
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter password : ");
        string password = Console.ReadLine()!;
        int result = UserProgramCode.validatePassword(password);
        Console.WriteLine(result);
    }
}
