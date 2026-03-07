using System;

class SalarySavings
{
    public double CalculateSavings(double input1, int input2)
    {
        if (input1 > 9000)
            return -1;

        if (input1 < 0)
            return -2;

        if (input2 < 0)
            return -4;

        double foodExpense = input1 * 0.50;
        double travelExpense = input1 * 0.20;
        double totalExpense = foodExpense + travelExpense;

        double savings = input1 - totalExpense;

        if (input2 == 31)
            savings += 500;

        return savings;
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter salary: ");
        double input1 = double.Parse(Console.ReadLine()!);

        Console.Write("Enter number of working days: ");
        int input2 = int.Parse(Console.ReadLine()!);

        SalarySavings obj = new SalarySavings();
        double output1 = obj.CalculateSavings(input1, input2);

        Console.WriteLine("Output: " + output1);
    }
}
