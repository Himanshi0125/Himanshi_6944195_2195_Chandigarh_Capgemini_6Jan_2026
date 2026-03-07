using System;
using System.Globalization;

class UserProgramCode
{
    public static string HandsOn5(string inputDate, int years)
    {
        DateTime date;

        if (!DateTime.TryParseExact(inputDate, "dd/MM/yyyy",
            CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            return "-1";

        if (years < 0)
            return "-2";

        return date.AddYears(years).ToString("dd/MM/yyyy");
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter date (dd/mm/yyyy) : ");
        string date = Console.ReadLine()!;
        Console.Write("Enter years : ");
        int years = int.Parse(Console.ReadLine()!);

        string result = UserProgramCode.HandsOn5(date, years);

        Console.WriteLine(result);
    }
}
