using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.Write("Enter string : ");
        string s = Console.ReadLine()!; //aabbcc

        Stack<char> stack = new Stack<char>();
        int deletions = 0;

        foreach (char c in s)
        {
            if (stack.Count > 0 && stack.Peek() == c)
            {
                stack.Pop();
                deletions++;
            }
            else
            {
                stack.Push(c);
            }
        }

        Console.WriteLine(deletions);
    }
}
