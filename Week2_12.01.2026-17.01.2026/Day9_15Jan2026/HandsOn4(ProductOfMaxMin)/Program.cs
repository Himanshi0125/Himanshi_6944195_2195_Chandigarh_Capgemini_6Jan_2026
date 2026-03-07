using System;

class ProductOfMaxMin
{
    public int CalculateProduct(int[] input1, int input2)
    {
        if (input2 < 0)
            return -2;

        for (int i = 0; i < input2; i++)
        {
            if (input1[i] < 0)
                return -1;
        }

        int max = input1[0];
        int min = input1[0];

        for (int i = 1; i < input2; i++)
        {
            if (input1[i] > max)
                max = input1[i];

            if (input1[i] < min)
                min = input1[i];
        }

        return max * min;
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter array size: ");
        int input2 = int.Parse(Console.ReadLine()!);

        int[] input1 = new int[input2];

        Console.WriteLine("Enter array elements:");
        for (int i = 0; i < input2; i++)
            input1[i] = int.Parse(Console.ReadLine()!);

        ProductOfMaxMin obj = new ProductOfMaxMin();
        int output = obj.CalculateProduct(input1, input2);

        Console.WriteLine("Output: " + output);
    }
}
