using System;

class DecimalToBinary
{
    public int[] ConvertToBinary(int input1)
    {
        if (input1 < 0)
            return new int[] { -1 };

        if (input1 == 0)
            return new int[] { 0 };

        int[] temp = new int[32];
        int index = 0;

        while (input1 > 0)
        {
            temp[index++] = input1 % 2;
            input1 /= 2;
        }

        // Reverse to get correct order
        int[] output = new int[index];
        for (int i = 0; i < index; i++)
        {
            output[i] = temp[index - 1 - i];
        }

        return output;
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter decimal number: ");
        int input1 = int.Parse(Console.ReadLine()!);

        DecimalToBinary obj = new DecimalToBinary();
        int[] output = obj.ConvertToBinary(input1);

        Console.Write("Output: ");
        foreach (int x in output)
            Console.Write(x + " ");
    }
}
