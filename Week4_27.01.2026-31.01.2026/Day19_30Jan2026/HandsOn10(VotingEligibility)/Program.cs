using System;

class UserProgramCode
{
    public static int checkVotingEligibility(int age)
    {
        if (age >= 18)
            return 1;
        return -1;
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter age : ");
        int age = int.Parse(Console.ReadLine()!);
        int result = UserProgramCode.checkVotingEligibility(age);
        Console.WriteLine(result);
    }
}
