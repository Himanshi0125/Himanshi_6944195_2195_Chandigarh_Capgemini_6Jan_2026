using System;
using System.Collections;

class Program
{
    static void Main()
    {
        Console.Write("Enter number : ");
        int num = int.Parse(Console.ReadLine()!);

        List<int> ans = new List<int>();

        for(int i = 1; i <= num/2; i++)
        {
            if (num % i == 0)
            {
                ans.Add(i);
            }
        }
        ans.Add(num);

        foreach(var i in ans)
        {
            Console.Write(i + " ");
        }
    }
}
