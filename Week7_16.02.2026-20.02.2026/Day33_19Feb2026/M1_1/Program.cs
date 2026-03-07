using System;
class Program
{
    static void Main()
    {
        Console.Write("Enter String : ");
        string str = Console.ReadLine()!;
        string result = "";
        int count = 0;
        char ch = str[0];

        foreach(char i in str)
        {
            if (i == ch)
            {
                count++;
            }
            else
            {
                result += ch;
                result += count;
                ch = i;
                count = 1;
            }
        }
        result += ch;
        result += count;

        Console.WriteLine("Compressed string : " + result);
    }
}