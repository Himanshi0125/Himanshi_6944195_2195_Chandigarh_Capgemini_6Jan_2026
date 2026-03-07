using System;

class Program
{
  static int CountValidWords(string input)
  {
    string[] words = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
    int count = 0;
    foreach (string word in words)
    {
      if (word.Length <= 2) continue;
      bool hasVowel = false;
      bool hasConsonant = false;
      bool valid = true;
      foreach (char c in word)
      {
        if (!char.IsLetterOrDigit(c))
        {
          valid = false;
          break;
        }
        if ("aeiouAEIOU".IndexOf(c) >= 0) hasVowel = true;
        else if (char.IsLetter(c)) hasConsonant = true;
      }
      if (valid && hasVowel && hasConsonant) count++;
    }
    return count;
  }

  static void Main()
  {
    string input = Console.ReadLine();
    Console.WriteLine(CountValidWords(input));
  }
}
