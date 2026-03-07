using System;

class Project
{
    public static string companyName;
    public const int maxTeamSize = 10;
    public readonly int projectId;
    public string projectName;
    public int teamSize;
    
    // static constructor
    static Project()
    {
        companyName = "Tech Solutions";
        Console.WriteLine("Company is Initialized");
    }

    // default constructor
    public Project()
    {
        projectId = 101;
        projectName = "Ecommerce";
        teamSize = 3;
    }
    // parameterized constructor
    public Project(int id, string name, int size)
    {
        projectId = id;
        projectName = name;
        teamSize = size;
    }
    public void display()
    {
        Console.WriteLine("Project ID: " + projectId);
        Console.WriteLine("Project Name: " + projectName);
        Console.WriteLine("Team Size: " + teamSize);
        Console.WriteLine();
    }

}

class Program
{
    static void Main()
    {
        Project p1 = new Project();
        Project p2 = new Project(102, "Healthcare", 5);
        p1.display();
        p2.display();

        Console.WriteLine("Company name is : " + Project.companyName);
        Console.WriteLine("Max Team Size Allowed: " + Project.maxTeamSize);
    }
}