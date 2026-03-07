using System;

class LuckyString
{
    static void Main()
    {
        Console.Write("Enter the length of substring : ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter the string (in uppercase) : ");
        string str = Console.ReadLine();

        if (n > str.Length)
        {
            Console.WriteLine("Invalid");
            return;
        }

        for (int i = 0; i <= str.Length - n; i++)
        {
            string sub = str.Substring(i, n);

            bool validChars = true;
            for (int j = 0; j < sub.Length; j++)
            {
                if (sub[j] != 'P' && sub[j] != 'S' && sub[j] != 'G')
                {
                    validChars = false;
                    break;
                }
            }

            if (!validChars)
                continue;

            // Check for n/2 consecutive same letters
            int count = 1;
            for (int j = 1; j < sub.Length; j++)
            {
                if (sub[j] == sub[j - 1])
                {
                    count++;
                    if (count >= n / 2)
                    {
                        Console.WriteLine("Yes");
                        return;
                    }
                }
                else
                {
                    count = 1;
                }
            }
        }

        Console.WriteLine("No");
    }
}
