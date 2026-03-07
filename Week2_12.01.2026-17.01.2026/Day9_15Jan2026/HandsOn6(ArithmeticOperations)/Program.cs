using System;

class ArithmeticOperations
{
    public double PerformOperation(double input1, double input2, int input3)
    {
        if (input1 < 0 && input2 < 0)
            return -1;

        double result = 0;

        switch (input3)
        {
            case 1:
                result = input1 + input2;
                break;

            case 2:
                result = input1 - input2;
                break;

            case 3:
                result = input1 * input2;
                break;

            case 4:
                result = input1 / input2;
                break;
        }

        return result;
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter input1: ");
        double input1 = double.Parse(Console.ReadLine()!);

        Console.Write("Enter input2: ");
        double input2 = double.Parse(Console.ReadLine()!);

        Console.Write("Enter input3 (1-Add, 2-Sub, 3-Mul, 4-Div): ");
        int input3 = int.Parse(Console.ReadLine()!);

        ArithmeticOperations obj = new ArithmeticOperations();
        double output = obj.PerformOperation(input1, input2, input3);

        Console.WriteLine("Output: " + output);
    }
}
