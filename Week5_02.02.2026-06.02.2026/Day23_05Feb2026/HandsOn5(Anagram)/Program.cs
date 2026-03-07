using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.Write("Enter string (comma-separated words) : ");
        string input = Console.ReadLine()!;   // dusty,study,dust,stydy

        string[] words = input.Split(',');

        string reference = String.Concat(words[0].OrderBy(c => c));

        bool allAnagrams = true;

        for (int i = 1; i < words.Length; i++)
        {
            string sortedWord = String.Concat(words[i].OrderBy(c => c));

            if (sortedWord != reference)
            {
                allAnagrams = false;
                break;
            }
        }

        Console.WriteLine(allAnagrams);
    }
}
