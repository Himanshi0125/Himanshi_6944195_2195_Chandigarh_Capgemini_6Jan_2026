using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter array size : ");
        int N = int.Parse(Console.ReadLine()!); 
        Console.Write("Enter elements : ");
        string[] input = Console.ReadLine()!.Split();

        int[] arr = new int[N];
        for (int i = 0; i < N; i++)
        {
            arr[i] = int.Parse(input[i]);
        }

        int count = 0;

        // Check adjacent (non-circular) couples
        for (int i = 0; i < N - 1; i++)
        {
            int sum = arr[i] + arr[i + 1];

            if (sum % N == 0)
            {
                count++;
            }
        }

        Console.WriteLine(count);
    }
}
