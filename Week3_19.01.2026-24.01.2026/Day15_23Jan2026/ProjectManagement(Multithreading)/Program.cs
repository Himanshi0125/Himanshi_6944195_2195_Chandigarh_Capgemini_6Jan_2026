using System;
using System.Threading;

class ProjectTasks
{
    public void Design()
    {
        Console.WriteLine("Design task started by " + Thread.CurrentThread.Name);
        Thread.Sleep(1000);
        Console.WriteLine("Design task completed");
    }

    public void Development()
    {
        Console.WriteLine("Development task started by " + Thread.CurrentThread.Name);
        Thread.Sleep(1000);
        Console.WriteLine("Development task completed");
    }

    public void Testing()
    {
        Console.WriteLine("Testing task started by " + Thread.CurrentThread.Name);
        Thread.Sleep(1000);
        Console.WriteLine("Testing task completed");
    }
}

class Program
{
    static void Main()
    {
        ProjectTasks project = new ProjectTasks();

        // Creating threads
        Thread t1 = new Thread(project.Design);
        Thread t2 = new Thread(project.Development);
        Thread t3 = new Thread(project.Testing);

        t1.Name = "Designer Thread";
        t2.Name = "Developer Thread";
        t3.Name = "Tester Thread";

        t1.Start();
        t2.Start();
        t3.Start();

        t1.Join();
        t2.Join();
        t3.Join();

        Console.WriteLine("Project Completed Successfully");
    }
}
