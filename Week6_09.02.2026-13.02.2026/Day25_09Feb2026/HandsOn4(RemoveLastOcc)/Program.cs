using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the string:");
        string input = Console.ReadLine();

        Console.WriteLine("Enter the word to remove:");
        string word = Console.ReadLine();

        int index = input.LastIndexOf(word);

        if (index != -1)
        {
            string result = input.Remove(index, word.Length);
            Console.WriteLine("String after removing last occurrence of '" + word + "':");
            Console.WriteLine(result);
        }
        else
        {
            Console.WriteLine("Word not found in the string.");
        }
    }
}
