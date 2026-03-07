using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.Write("Enter string1 : ");
        string s1 = Console.ReadLine()!;
        Console.Write("Enter string2 : ");
        string s2 = Console.ReadLine()!;

        s1 = s1.ToLower();
        s2 = s2.ToLower();

        if (s1.Length != s2.Length)
        {
            Console.WriteLine("Strings are Not Anagrams");
            return;
        }

        Dictionary<char, int> freq = new Dictionary<char, int>();

        foreach (char c in s1)
        {
            if (freq.ContainsKey(c))
                freq[c]++;
            else
                freq[c] = 1;
        }

        foreach (char c in s2){
            if (!freq.ContainsKey(c))
            {
                Console.WriteLine("Strings are Not Anagrams");
                return;
            }

            freq[c]--;
        }

        foreach (var item in freq){
            if (item.Value != 0)
            {
                Console.WriteLine("Strings are Not Anagrams");
                return;
            }
        }

        Console.WriteLine("Strings are Anagrams");
    }
}
