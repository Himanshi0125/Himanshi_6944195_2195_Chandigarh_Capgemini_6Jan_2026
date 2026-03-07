using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter pipe separated words:");
        string input = Console.ReadLine();

        string[] words = input.Split('|');
        Array.Reverse(words);

        string result = string.Join("|", words);

        Console.WriteLine(result);
    }
}
