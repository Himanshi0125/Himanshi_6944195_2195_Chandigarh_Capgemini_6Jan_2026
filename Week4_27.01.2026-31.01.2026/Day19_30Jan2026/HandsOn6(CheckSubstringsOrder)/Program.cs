using System;

class UserProgramCode
{
    public static int HandsOn6(string input1, string input2, string input3)
    {
        int index2 = input1.IndexOf(input2);
        int index3 = input1.IndexOf(input3);

        if (index2 == -1 || index3 == -1)
            return -1;

        if (index3 > index2)
            return 1;

        return -1;
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter String : ");
        string input1 = Console.ReadLine()!;
        Console.Write("Enter String : ");
        string input2 = Console.ReadLine()!;
        Console.Write("Enter String : ");
        string input3 = Console.ReadLine()!;

        int result = UserProgramCode.HandsOn6(input1, input2, input3);
        Console.WriteLine(result);
    }
}
