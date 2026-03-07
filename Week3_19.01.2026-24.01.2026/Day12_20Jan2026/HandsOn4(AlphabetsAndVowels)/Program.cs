using System;

class MahirlAndAlphabets
{
    static bool IsVowel(char ch)
    {
        ch = char.ToLower(ch);
        return ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u';
    }

    static void Main()
    {
        string first = Console.ReadLine();
        string second = Console.ReadLine().ToLower();

        string temp = "";

        // Step 1: Remove common consonants
        for (int i = 0; i < first.Length; i++)
        {
            char ch = first[i];
            char lowerCh = char.ToLower(ch);

            if (!IsVowel(ch) && second.Contains(lowerCh))
                continue;

            temp += ch;
        }

        // Step 2: Remove consecutive duplicates
        string result = "";

        for (int i = 0; i < temp.Length; i++)
        {
            if (i == 0 || temp[i] != temp[i - 1])
                result += temp[i];
        }

        Console.WriteLine(result);
    }
}
