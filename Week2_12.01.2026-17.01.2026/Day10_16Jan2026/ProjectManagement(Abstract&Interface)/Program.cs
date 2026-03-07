using System;

interface ITaskManagement
{
    void AssignTask();
    void StartTask();
    void UpdateTask();
    void CompleteTask();
    void ViewTaskStatus();
}

interface IReporting
{
    void CreateReport();
    void SubmitReport();
    void ViewReport();
    void EditReport();
    void DeleteReport();
}

class ProjectManager : ITaskManagement, IReporting
{
    public void AssignTask()
    {
        Console.WriteLine("Task assigned to team member.");
    }

    public void StartTask()
    {
        Console.WriteLine("Task started.");
    }

    public void UpdateTask()
    {
        Console.WriteLine("Task updated.");
    }

    public void CompleteTask()
    {
        Console.WriteLine("Task completed.");
    }

    public void ViewTaskStatus()
    {
        Console.WriteLine("Viewing task status.");
    }

    public void CreateReport()
    {
        Console.WriteLine("Report created.");
    }

    public void SubmitReport()
    {
        Console.WriteLine("Report submitted.");
    }

    public void ViewReport()
    {
        Console.WriteLine("Viewing report.");
    }

    public void EditReport()
    {
        Console.WriteLine("Report edited.");
    }

    public void DeleteReport()
    {
        Console.WriteLine("Report deleted.");
    }
}

class Program
{
    static void Main()
    {
        ProjectManager manager = new ProjectManager();

        manager.AssignTask();
        manager.StartTask();
        manager.CompleteTask();

        manager.CreateReport();
        manager.SubmitReport();
    }
}
