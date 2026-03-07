using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.Write("Enter number of elements: ");
        int n = int.Parse(Console.ReadLine());

        List<int> list = new List<int>();
        Console.WriteLine("Enter elements:");
        for (int i = 0; i < n; i++)
            list.Add(int.Parse(Console.ReadLine()));

        Console.Write("Enter target value: ");
        int target = int.Parse(Console.ReadLine());

        List<int> result = Logic.GetElements(list, target);

        if (result.Count == 1 && result[0] == -1)
            Console.WriteLine("No element found");
        else
        {
            Console.WriteLine("Output:");
            foreach (int x in result)
                Console.Write(x + " ");
        }
    }
}

class Logic
{
    public static List<int> GetElements(List<int> input1, int input2)
    {
        List<int> result = new List<int>();

        foreach (int x in input1)
        {
            if (x < input2)
                result.Add(x);
        }

        if (result.Count == 0)
            return new List<int> { -1 };

        result.Sort();
        result.Reverse();
        return result;
    }
}