using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.Write("Enter size of array: ");
        int n = int.Parse(Console.ReadLine());

        int[] arr = new int[n];
        Console.WriteLine("Enter elements:");
        for (int i = 0; i < n; i++)
            arr[i] = int.Parse(Console.ReadLine());

        int result = Logic.MaxDiff(arr);
        Console.WriteLine("Output: " + result);
    }
}

class Logic
{
    public static int MaxDiff(int[] input1)
    {
        int n = input1.Length;

        // Rule: size = 1 or >10
        if (n == 1 || n > 10)
            return -2;

        HashSet<int> set = new HashSet<int>();

        foreach (int x in input1)
        {
            if (x < 0)
                return -1;      // negative number

            if (set.Contains(x))
                return -3;      // duplicate

            set.Add(x);
        }

        int min = input1[0];
        int maxDiff = int.MinValue;

        for (int i = 1; i < n; i++)
        {
            maxDiff = Math.Max(maxDiff, input1[i] - min);
            min = Math.Min(min, input1[i]);
        }

        return maxDiff;
    }
}