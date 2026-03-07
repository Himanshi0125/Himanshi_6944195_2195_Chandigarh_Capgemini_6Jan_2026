using System;
using System.Collections.Generic;

// ENUMS
enum Role
{
    Admin = 1,
    Manager,
    TeamMember
}

enum ProjectStatus
{
    NotStarted,
    InProgress,
    Completed
}

enum TaskStatus
{
    Pending,
    InProgress,
    Done
}

// STRUCTS
struct Project
{
    public int ProjectId;
    public string ProjectName;
    public string ManagerName;
    public DateTime StartDate;
    public DateTime EndDate;
    public int MemberCount;
    public ProjectStatus Status;
}

struct TeamMember
{
    public int MemberId;
    public string MemberName;
    public string ProjectName;
    public string Role;
    public string Task;
    public TaskStatus TaskStatus;
}

// MAIN PROGRAM
class Program
{
    static List<Project> projects = new List<Project>();
    static List<TeamMember> teamMembers = new List<TeamMember>();

    static void Main()
    {
        Console.WriteLine("===== PROJECT MANAGEMENT SYSTEM =====");
        Console.WriteLine("Select Role:");
        Console.WriteLine("1. Admin");
        Console.WriteLine("2. Manager");
        Console.WriteLine("3. Team Member");

        Role role = (Role)Convert.ToInt32(Console.ReadLine());

        switch (role)
        {
            case Role.Admin:
                AdminMenu();
                break;

            case Role.Manager:
                ManagerMenu();
                break;

            case Role.TeamMember:
                TeamMemberMenu();
                break;

            default:
                Console.WriteLine("Invalid Role");
                break;
        }
    }

    // ================= ADMIN =================
    static void AdminMenu()
    {
        int choice;
        do
        {
            Console.WriteLine("\n--- ADMIN MENU ---");
            Console.WriteLine("1. Add Project");
            Console.WriteLine("2. Add Team Member");
            Console.WriteLine("3. View All Projects");
            Console.WriteLine("4. Exit");

            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddProject();
                    break;
                case 2:
                    AddTeamMember();
                    break;
                case 3:
                    ViewAllProjects();
                    break;
            }

        } while (choice != 4);
    }

    static void AddProject()
    {
        Project p = new Project();

        Console.Write("Project ID: ");
        p.ProjectId = Convert.ToInt32(Console.ReadLine());

        Console.Write("Project Name: ");
        p.ProjectName = Console.ReadLine();

        Console.Write("Manager Name: ");
        p.ManagerName = Console.ReadLine();

        Console.Write("Start Date: ");
        p.StartDate = DateTime.Parse(Console.ReadLine());

        Console.Write("End Date: ");
        p.EndDate = DateTime.Parse(Console.ReadLine());

        Console.Write("Number of Members: ");
        p.MemberCount = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Status (0-NotStarted 1-InProgress 2-Completed): ");
        p.Status = (ProjectStatus)Convert.ToInt32(Console.ReadLine());

        projects.Add(p);
        Console.WriteLine("✅ Project Added");
    }

    static void AddTeamMember()
    {
        TeamMember tm = new TeamMember();

        Console.Write("Member ID: ");
        tm.MemberId = Convert.ToInt32(Console.ReadLine());

        Console.Write("Member Name: ");
        tm.MemberName = Console.ReadLine();

        Console.Write("Project Name: ");
        tm.ProjectName = Console.ReadLine();

        Console.Write("Role in Team: ");
        tm.Role = Console.ReadLine();

        Console.Write("Task: ");
        tm.Task = Console.ReadLine();

        Console.WriteLine("Task Status (0-Pending 1-InProgress 2-Done): ");
        tm.TaskStatus = (TaskStatus)Convert.ToInt32(Console.ReadLine());

        teamMembers.Add(tm);
        Console.WriteLine("✅ Team Member Added");
    }

    static void ViewAllProjects()
    {
        foreach (var p in projects)
        {
            Console.WriteLine($"\nProject ID: {p.ProjectId}");
            Console.WriteLine($"Project Name: {p.ProjectName}");
            Console.WriteLine($"Manager: {p.ManagerName}");
            Console.WriteLine($"Start: {p.StartDate.ToShortDateString()}");
            Console.WriteLine($"End: {p.EndDate.ToShortDateString()}");
            Console.WriteLine($"Members: {p.MemberCount}");
            Console.WriteLine($"Status: {p.Status}");
        }
    }

    // ================= MANAGER =================
    static void ManagerMenu()
    {
        Console.Write("Enter Manager Name: ");
        string managerName = Console.ReadLine();

        foreach (var p in projects)
        {
            if (p.ManagerName == managerName)
            {
                Console.WriteLine($"\nProject ID: {p.ProjectId}");
                Console.WriteLine($"Status: {p.Status}");
                Console.WriteLine("Team Members:");

                foreach (var tm in teamMembers)
                {
                    if (tm.ProjectName == p.ProjectName)
                    {
                        Console.WriteLine($"- {tm.MemberName} ({tm.Role})");
                    }
                }
                return;
            }
        }

        Console.WriteLine("❌ No project found for this manager");
    }

    // ================= TEAM MEMBER =================
    static void TeamMemberMenu()
    {
        Console.Write("Enter Member ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

        foreach (var tm in teamMembers)
        {
            if (tm.MemberId == id)
            {
                Console.WriteLine($"\nMember Name: {tm.MemberName}");
                Console.WriteLine($"Project: {tm.ProjectName}");
                Console.WriteLine($"Task: {tm.Task}");
                Console.WriteLine($"Task Status: {tm.TaskStatus}");
                return;
            }
        }

        Console.WriteLine("❌ Team Member not found");
    }
}
