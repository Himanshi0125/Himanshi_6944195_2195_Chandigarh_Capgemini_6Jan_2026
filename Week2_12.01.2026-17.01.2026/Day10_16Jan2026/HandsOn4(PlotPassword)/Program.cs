using System;

class PlotPasswordCalculator
{
    public int CalculatePassword(int[] input1, int input2)
    {
        if (input2 < 0)
            return -2;

        int sumOdd = 0;
        int sumEven = 0;

        for (int i = 0; i < input2; i++)
        {
            if (input1[i] < 0)
                return -1;

            if (input1[i] % 2 == 0)
                sumEven += input1[i];
            else
                sumOdd += input1[i];
        }

        int password = (sumOdd + sumEven) / 2;
        return password;
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter array size: ");
        int input2 = int.Parse(Console.ReadLine()!);

        int[] input1 = new int[input2];

        Console.WriteLine("Enter plot numbers:");
        for (int i = 0; i < input2; i++)
            input1[i] = int.Parse(Console.ReadLine()!);

        PlotPasswordCalculator obj = new PlotPasswordCalculator();
        int output1 = obj.CalculatePassword(input1, input2);

        Console.WriteLine("Output: " + output1);
    }
}
