using System;
using System.Runtime.CompilerServices;

class CountVowels
{
    static void Main()
    {
        Console.Write("Enter string : ");
        string str = Console.ReadLine()!;
        str = str.ToLower();
        int count = 0;

        foreach (char ch in str)
        {
            if (ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u')
            {
                count++;
            }
        }
        Console.WriteLine("Count of Vowels is : " + count);
    }
}