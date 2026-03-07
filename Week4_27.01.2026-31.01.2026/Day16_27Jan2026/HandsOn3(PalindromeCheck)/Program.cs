using System;
using System.Runtime.CompilerServices;

class PalindromeCheck
{
    static void Main()
    {
        Console.Write("Enter string : ");
        string str = Console.ReadLine()!;
        str = str.ToLower();

        int left = 0;
        int right = str.Length-1;
        bool check = true;

        while(left < right)
        {
            if (str[left] != str[right])
            {
                check = false;
            }
            left++; right--;
        }

        if (check)
        {
            Console.WriteLine("The string is a Palindrome");
        }
        else
        {
            Console.WriteLine("The string is not a Palindrome");
        }

    }
}