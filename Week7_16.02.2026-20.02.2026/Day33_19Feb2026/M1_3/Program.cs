using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Enter size : ");
        int n = int.Parse(Console.ReadLine()!);

        int[] arr = new int[n];
        Console.WriteLine("Enter the elements of array : ");
        for(int i = 0; i < n; i++)
        {
            arr[i] = int.Parse(Console.ReadLine()!);
        }

        Dictionary<int, int> freq = new Dictionary<int, int>();

        foreach(int i in arr)
        {
            if (freq.ContainsKey(i))
            {
                freq[i]++;
            }
            else
            {
                freq.Add(i, 1);
            }
        }

        foreach(var pair in freq)
        {
            Console.WriteLine(pair.Key + " occurs " + pair.Value + " times.");
        }
    }
}