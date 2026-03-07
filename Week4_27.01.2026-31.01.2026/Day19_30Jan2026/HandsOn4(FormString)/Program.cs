using System;
using System.Text;

class UserProgramCode
{
    public static string formString(string[] input1, int input2)
    {
        StringBuilder sb = new StringBuilder();

        foreach (string s in input1)
        {
            foreach (char c in s)
                if (!char.IsLetter(c))
                    return "-1";

            if (input2 <= s.Length)
                sb.Append(s[input2 - 1]);
            else
                sb.Append('$');
        }
        return sb.ToString();
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter Size : ");
        int k = int.Parse(Console.ReadLine()!);
        string[] arr = new string[k];

        Console.WriteLine("Enter elements : ");
        for (int i = 0; i < k; i++)
            arr[i] = Console.ReadLine()!;

        Console.Write("Enter nth element : ");
        int n = int.Parse(Console.ReadLine()!);

        string result = UserProgramCode.formString(arr, n);
        Console.WriteLine(result);
    }
}
