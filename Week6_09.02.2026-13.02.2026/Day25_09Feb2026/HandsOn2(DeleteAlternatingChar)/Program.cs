using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.Write("Enter String : ");
        string s = Console.ReadLine()!;   // abcdef

        StringBuilder result = new StringBuilder();

        for (int i = 0; i < s.Length; i++)
        {
            if (i % 2 == 0) 
            {
                result.Append(s[i]);
            }
        }

        Console.WriteLine(result.ToString());
    }
}
