using System;

public abstract class Employee
{
    protected string department;
    protected string name;
    protected string location;
    protected bool isOnVacation = false;

    public Employee(string department, string name, string location)
    {
        this.department = department;
        this.name = name;
        this.location = location;
    }

    public string GetDepartment()
    {
        return department;
    }

    public string GetName()
    {
        return name;
    }

    public string GetLocation()
    {
        return location;
    }

    public bool GetStatus()
    {
        return isOnVacation;
    }

    public void SwitchStatus()
    {
        isOnVacation = !isOnVacation;
    }
}

public class FinanceEmployee : Employee
{
    public FinanceEmployee(string name, string location)
        : base("Finance", name, location)
    {
    }
}

public class MarketingEmployee : Employee
{
    public MarketingEmployee(string name, string location)
        : base("Marketing", name, location)
    {
    }
}

class Solution
{
    static void PrintStatus(Employee emp)
    {
        if (emp.GetStatus())
            Console.WriteLine(emp.GetName() + " is on vacation");
        else
            Console.WriteLine(emp.GetName() + " is not on vacation");
    }

    static void Main()
    {
        var input1 = Console.ReadLine().Split();
        var input2 = Console.ReadLine().Split();

        FinanceEmployee financeEmp = new FinanceEmployee(input1[0], input1[1]);
        MarketingEmployee marketingEmp = new MarketingEmployee(input2[0], input2[1]);

        Console.WriteLine("FinanceEmployee info: Department - " + financeEmp.GetDepartment() +
                          ", Name - " + financeEmp.GetName() +
                          ", Location - " + financeEmp.GetLocation());

        PrintStatus(financeEmp);

        Console.WriteLine("Switching");
        financeEmp.SwitchStatus();
        PrintStatus(financeEmp);

        Console.WriteLine("Switching");
        financeEmp.SwitchStatus();
        PrintStatus(financeEmp);

        Console.WriteLine("MarketingEmployee info: Department - " + marketingEmp.GetDepartment() +
                          ", Name - " + marketingEmp.GetName() +
                          ", Location - " + marketingEmp.GetLocation());

        PrintStatus(marketingEmp);

        Console.WriteLine("Switching");
        marketingEmp.SwitchStatus();
        PrintStatus(marketingEmp);

        Console.WriteLine("Switching");
        marketingEmp.SwitchStatus();
        PrintStatus(marketingEmp);
    }
}