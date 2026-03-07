using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter String : ");
        string str = Console.ReadLine()!;
        Console.Write("Enter position : ");
        int pos = int.Parse(Console.ReadLine()!);
        Console.Write("Enter Substring : ");
        string substr = Console.ReadLine()!;
        
        string left = "";
        string right = "";

        for(int i = 0; i < str.Length; i++)
        {
            if (i < pos)
            {
                left += str[i];
            }
            else
            {
                right += str[i];
            }
        }

        string result = left + substr + right;
        

        Console.WriteLine("new string is : " + result);
    }
}
