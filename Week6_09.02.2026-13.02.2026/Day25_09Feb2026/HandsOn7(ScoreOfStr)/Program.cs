using System;

class Program
{
    static void Main()
    {
        string str = Console.ReadLine(); //ABCBAAAA
        int score = 0;

        for (int i = 0; i <= str.Length - 4; i++)
        {
            if (IsPalindrome(str.Substring(i, 4)))
            {
                score += 5;
            }
        }

        for (int i = 0; i <= str.Length - 5; i++)
        {
            if (IsPalindrome(str.Substring(i, 5)))
            {
                score += 10;
            }
        }

        Console.WriteLine(score);
    }

    static bool IsPalindrome(string s)
    {
        int left = 0;
        int right = s.Length - 1;

        while (left < right)
        {
            if (s[left] != s[right])
                return false;

            left++;
            right--;
        }

        return true;
    }
}
