using System;

class GrossSalaryCalculator
{
    public double CalculateGrossSalary(double basicPay, int workingDays)
    {
        if (basicPay < 0)
            return -1;

        if (basicPay > 10000)
            return -2;

        if (workingDays > 31)
            return -3;

        double da = basicPay * 0.75;
        double hra = basicPay * 0.50;

        double grossSalary = basicPay + da + hra;

        return grossSalary;
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter basic salary: ");
        double input1 = double.Parse(Console.ReadLine()!);

        Console.Write("Enter working days: ");
        int input2 = int.Parse(Console.ReadLine()!);

        GrossSalaryCalculator obj = new GrossSalaryCalculator();
        double output = obj.CalculateGrossSalary(input1, input2);

        Console.WriteLine("Output: " + output);
    }
}
