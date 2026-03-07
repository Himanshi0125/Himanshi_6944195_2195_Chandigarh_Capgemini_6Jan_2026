using System;
using System.Collections.Generic;
using System.Diagnostics;

class UserProgramCode
{
    public static int convertRomanToDecimal(string input)
    {
        // Roman character values
        Dictionary<char, int> romanValues = new Dictionary<char, int>()
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };

        int sum = 0;

        for (int i = 0; i < input.Length; i++)
        {
            char ch = input[i];

            // Business rule: invalid character
            if (!romanValues.ContainsKey(ch))
                return -1;

            sum += romanValues[ch];
        }

        return sum;
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter Roman Numbers : ");
        string input = Console.ReadLine()!;
        int output = UserProgramCode.convertRomanToDecimal(input);
        Console.WriteLine(output);
    }
}
