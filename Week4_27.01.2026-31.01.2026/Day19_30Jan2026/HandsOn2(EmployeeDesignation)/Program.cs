using System;
using System.Collections.Generic;

class UserProgramCode
{
    public static string[] getEmployee(string[] input1, string input2)
    {
        if (!IsValid(input2))
            return new string[] { "Invalid Input" };

        foreach (string s in input1)
            if (!IsValid(s))
                return new string[] { "Invalid Input" };

        List<string> employees = new List<string>();
        HashSet<string> designations = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        for (int i = 1; i < input1.Length; i += 2)
            designations.Add(input1[i]);

        if (designations.Count == 1 && designations.Contains(input2))
            return new string[] { "All employees belong to same " + input2 + " designation" };

        for (int i = 0; i < input1.Length - 1; i += 2)
            if (input1[i + 1].Equals(input2, StringComparison.OrdinalIgnoreCase))
                employees.Add(input1[i]);

        if (employees.Count == 0)
            return new string[] { "No employee for " + input2 + " designation" };

        return employees.ToArray();
    }

    static bool IsValid(string s)
    {
        foreach (char c in s)
            if (!char.IsLetter(c) && c != ' ')
                return false;
        return true;
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

        Console.Write("Enter Designation : ");
        string designation = Console.ReadLine()!;

        string[] result = UserProgramCode.getEmployee(arr, designation);

        if (result.Length == 1)
            Console.WriteLine(result[0]);
        else
            Console.WriteLine(string.Join(" ", result));
    }
}
