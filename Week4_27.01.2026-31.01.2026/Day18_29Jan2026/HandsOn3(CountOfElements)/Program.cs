using System;

class UserProgramCode
{
    public static int GetCount(int size, string[] input1, char input2)
    {
        int count = 0;

        foreach (string str in input1)
        {
            foreach (char ch in str)
            {
                if (!char.IsLetter(ch))
                    return -2;
            }

            if (str.Length > 0 &&
                char.ToLower(str[0]) == char.ToLower(input2))
            {
                count++;
            }
        }

        if (count == 0)
            return -1;

        return count;
    }
}

class Program
{
    static void Main()
    {
        int size = int.Parse(Console.ReadLine()!);
        string[] input1 = new string[size];

        for (int i = 0; i < size; i++)
        {
            input1[i] = Console.ReadLine()!;
        }

        char input2 = char.Parse(Console.ReadLine()!);

        int result = UserProgramCode.GetCount(size, input1, input2);

        if (result == -1)
            Console.WriteLine("No elements Found");
        else if (result == -2)
            Console.WriteLine("Only alphabets should be given");
        else
            Console.WriteLine(result);
    }
}
