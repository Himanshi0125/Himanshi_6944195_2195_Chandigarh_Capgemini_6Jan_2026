using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter string (words separated by space) : ");
        string[] words = Console.ReadLine()!.Split();

        Dictionary<string, int> map = new Dictionary<string, int>();

        foreach (string word in words)
        {
            string key = String.Concat(word.OrderBy(c => c));

            if (!map.ContainsKey(key))
                map[key] = 0;

            map[key]++;
        }

        List<string> uniqueWords = new List<string>();

        foreach (string word in words)
        {
            string key = String.Concat(word.OrderBy(c => c));

            if (map[key] == 1)
                uniqueWords.Add(word);
        }

        Console.WriteLine(string.Join(" ", uniqueWords));
    }
}
