using System;

class UserProgramCode
{
    public static int sumOfDigits(string[] input1)
    {
        int sum = 0;

        foreach (string s in input1)
        {
            foreach (char c in s)
            {
                if (!char.IsLetterOrDigit(c) && c != ' ')
                    return -1;

                if (char.IsDigit(c))
                    sum += c - '0';
            }
        }
        return sum;
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter size : ");
        int n = int.Parse(Console.ReadLine()!);
        string[] arr = new string[n];

        Console.WriteLine("Enter elements : ");
        for (int i = 0; i < n; i++)
            arr[i] = Console.ReadLine()!;

        int result = UserProgramCode.sumOfDigits(arr);
        Console.WriteLine("Result is : " + result);
    }
}
