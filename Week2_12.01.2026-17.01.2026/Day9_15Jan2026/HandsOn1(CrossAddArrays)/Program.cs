using System;

class CrossAddArrays
{
    public int[] ProcessArrays(int[] input1, int[] input2, int input3)
    {
        if (input3 < 0)
            return new int[] { -2 };

        for (int i = 0; i < input3; i++)
        {
            if (input1[i] < 0 || input2[i] < 0)
                return new int[] { -1 };
        }

        int[] output = new int[input3];

        for (int i = 0; i < input3; i++)
        {
            output[i] = input1[i] + input2[input3 - 1 - i];
        }

        return output;
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter size of arrays: ");
        int input3 = int.Parse(Console.ReadLine()!);

        int[] input1 = new int[input3];
        int[] input2 = new int[input3];

        Console.WriteLine("Enter elements of first array:");
        for (int i = 0; i < input3; i++)
        {
            input1[i] = int.Parse(Console.ReadLine()!);
        }

        Console.WriteLine("Enter elements of second array:");
        for (int i = 0; i < input3; i++)
        {
            input2[i] = int.Parse(Console.ReadLine()!);
        }

        CrossAddArrays obj = new CrossAddArrays();
        int[] result = obj.ProcessArrays(input1, input2, input3);

        Console.Write("Output: ");
        foreach (int x in result)
        {
            Console.Write(x + " ");
        }
    }
}
