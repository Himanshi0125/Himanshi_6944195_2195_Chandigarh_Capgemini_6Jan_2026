using System;

class SumOfFactorsUptoN
{
    public int CalculateSum(int input1, int input2)
    {
        if (input1 < 0)
            return -1;

        if (input2 > 32627)
            return -2;

        int sum = 0;
        for (int i = input1; i <= input2; i += input1)
        {
            sum += i;
        }
        return sum;
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter input1 (factor): ");
        int input1 = int.Parse(Console.ReadLine()!);

        Console.Write("Enter input2 (limit): ");
        int input2 = int.Parse(Console.ReadLine()!);

        SumOfFactorsUptoN obj = new SumOfFactorsUptoN();
        int output1 = obj.CalculateSum(input1, input2);

        Console.WriteLine("Output: " + output1);
    }
}
