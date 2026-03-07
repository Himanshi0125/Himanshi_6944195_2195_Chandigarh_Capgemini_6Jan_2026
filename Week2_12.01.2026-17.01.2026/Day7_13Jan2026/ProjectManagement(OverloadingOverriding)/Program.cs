using System;

class Employee
{
    public void AssignTask()
    {
        Console.WriteLine("Employee assigned a general task.");
    }

    public void AssignTask(string taskName)
    {
        Console.WriteLine("Employee assigned task: " + taskName);
    }

    public virtual void WorkStatus()
    {
        Console.WriteLine("Employee is working.");
    }
}

class Manager : Employee
{
    public override void WorkStatus()
    {
        Console.WriteLine("Manager is supervising the team.");
    }
}

class Program
{
    static void Main()
    {
        Employee emp = new Employee();
        emp.AssignTask();                     
        emp.AssignTask("Documentation");

        emp.WorkStatus();                    

        Manager mgr = new Manager();
        mgr.AssignTask("Project Planning"); 
        mgr.WorkStatus();                   
    }
}
