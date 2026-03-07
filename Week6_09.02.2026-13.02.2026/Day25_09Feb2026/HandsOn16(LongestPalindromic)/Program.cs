// See https://aka.ms/new-console-template for more information
using System;

class Program
{
  static void Main(string[] args)
  {
    Console.Write("Enter the string: ");
    string? s = Console.ReadLine();
    if (s == null)
    {
      Console.WriteLine("Invalid input.");
      return;
    }

    int maxLen = LongestPalindrome(s);
    Console.WriteLine("Length: " + maxLen);
  }

  static int LongestPalindrome(string s)
  {
    if (s.Length == 0) return 0;
    int maxLen = 1;
    for (int i = 0; i < s.Length; i++)
    {
      // Odd length
      int len1 = ExpandAroundCenter(s, i, i);
      // Even length
      int len2 = ExpandAroundCenter(s, i, i + 1);
      maxLen = Math.Max(maxLen, Math.Max(len1, len2));
    }
    return maxLen;
  }

  static int ExpandAroundCenter(string s, int left, int right)
  {
    while (left >= 0 && right < s.Length && s[left] == s[right])
    {
      left--;
      right++;
    }
    return right - left - 1;
  }
}
