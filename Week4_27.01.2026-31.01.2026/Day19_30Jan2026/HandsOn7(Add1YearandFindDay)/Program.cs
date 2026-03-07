using System;
using System.Globalization;

class UserProgramCode
{
    public static string HandsOn7(string inputDate)
    {
        DateTime date;

        if (!DateTime.TryParseExact(inputDate, "dd/MM/yyyy",
            CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            return "-1";

        DateTime newDate = date.AddYears(1);
        return newDate.DayOfWeek.ToString();
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter date (dd/mm/yyyy) : ");
        string date = Console.ReadLine()!;

        string result = UserProgramCode.HandsOn7(date);
        Console.WriteLine(result);
    }
}
