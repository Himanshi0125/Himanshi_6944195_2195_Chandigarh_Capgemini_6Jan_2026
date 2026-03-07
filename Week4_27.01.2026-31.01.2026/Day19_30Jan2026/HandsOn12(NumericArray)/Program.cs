using System;

class UserProgramCode
{
    public static int checkNumericArray(string[] input1)
    {
        foreach (string s in input1)
        {
            double num;
            if (!double.TryParse(s, out num))
                return -1;
        }
        return 1;
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter size of array : ");
        int n = int.Parse(Console.ReadLine()!);
        string[] arr = new string[n];
        Console.WriteLine("Enter elements : ");
        for (int i = 0; i < n; i++)
            arr[i] = Console.ReadLine()!;

        int result = UserProgramCode.checkNumericArray(arr);
        Console.WriteLine(result);
    }
}
