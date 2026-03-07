using System;

class UserProgramCode
{
    public static int countTripleCharacters(string input1)
    {
        int count = 0;

        for (int i = 0; i < input1.Length - 2; i++)
        {
            if (input1[i] == input1[i + 1] && input1[i] == input1[i + 2])
                count++;
        }
        return count;
    }
}

class Program
{
    static void Main()
    {
        Console.Write("enter string : ");
        string input = Console.ReadLine()!;
        int result = UserProgramCode.countTripleCharacters(input);
        Console.WriteLine(result);
    }
}
