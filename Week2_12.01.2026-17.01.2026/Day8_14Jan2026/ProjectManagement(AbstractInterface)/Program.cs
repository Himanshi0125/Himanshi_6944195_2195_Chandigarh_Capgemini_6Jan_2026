using System;

interface IReportable
{
    void GenerateReport();
}
abstract class Employee
{
    public string Name;
    public Employee(string name)
    {
        Name = name;
    }
    public abstract void Work();
    public virtual void ShowRole()
    {
        Console.WriteLine("Employee role");
    }
}

class Manager : Employee, IReportable
{
    public Manager(string name) : base(name) { }

    public override void Work()
    {
        Console.WriteLine(Name + " is managing the project.");
    }
    public override void ShowRole()
    {
        Console.WriteLine("Role: Manager");
    }
    public void GenerateReport()
    {
        Console.WriteLine(Name + " is generating report.");
    }
}

class Developer : Employee, IReportable
{
    public Developer(string name) : base(name) { }
    public override void Work()
    {
        Console.WriteLine(Name + " is coding the application.");
    }
    public override void ShowRole()
    {
        Console.WriteLine("Role: Developer");
    }
    public void GenerateReport()
    {
        Console.WriteLine(Name + " is submitting development report.");
    }
}

class Program
{
    static void Main()
    {
        Employee emp1 = new Manager("Himanshi");
        Employee emp2 = new Developer("Kashish");

        emp1.ShowRole();
        emp1.Work();

        emp2.ShowRole();
        emp2.Work();

        IReportable r1 = (IReportable)emp1;
        IReportable r2 = (IReportable)emp2;
        
        r1.GenerateReport();
        r2.GenerateReport();
    }
}
