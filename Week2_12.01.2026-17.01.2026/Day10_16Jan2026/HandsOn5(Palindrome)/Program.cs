using System;

class PalindromeNumber
{
    public int CheckPalindrome(int input)
    {
        if (input < 0)
            return -1;

        int original = input;
        int reverse = 0;

        while (input > 0)
        {
            int digit = input % 10;
            reverse = reverse * 10 + digit;
            input /= 10;
        }

        if (original == reverse)
            return 1;
        else
            return -2;
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int input = int.Parse(Console.ReadLine()!);

        PalindromeNumber obj = new PalindromeNumber();
        int output = obj.CheckPalindrome(input);

        Console.WriteLine("Output: " + output);
    }
}
