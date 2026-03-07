using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the string:");
        string input = Console.ReadLine();

        Console.WriteLine("Enter character to replace:");
        char oldChar = char.Parse(Console.ReadLine());

        Console.WriteLine("Enter character to replace with:");
        char newChar = char.Parse(Console.ReadLine());

        int index = input.IndexOf(oldChar);

        if (index != -1)
        {
            string result = input.Remove(index, 1)
                                 .Insert(index, newChar.ToString());

            Console.WriteLine("String after replacing '" + oldChar + "' with '" + newChar + "':");
            Console.WriteLine(result);
        }
        else
        {
            Console.WriteLine("Character not found in the string.");
        }
    }
}
