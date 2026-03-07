using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter the string: ");
        string str = Console.ReadLine()!;

        Console.Write("Enter the character to insert: ");
        char ch = char.Parse(Console.ReadLine()!);

        Console.Write("Enter the position: ");
        int position = int.Parse(Console.ReadLine()!);

        string result = str.Substring(0, position) + ch + str.Substring(position);

        Console.WriteLine(result);
    }
}
