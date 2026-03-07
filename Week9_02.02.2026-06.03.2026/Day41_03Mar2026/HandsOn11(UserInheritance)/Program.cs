using System;

public enum Gender
{
    Male,
    Female,
    Other
}

public abstract class User
{
    protected string type;
    protected string name;
    protected Gender gender;
    protected int age;

    public User(string type, string name, Gender gender, int age)
    {
        this.type = type;
        this.name = name;
        this.gender = gender;
        this.age = age;
    }

    public string GetUserName()
    {
        return name;
    }

    public string GetUserType()
    {
        return type;
    }

    public int GetAge()
    {
        return age;
    }

    public Gender GetGender()
    {
        return gender;
    }
}

public class Admin : User
{
    public Admin(string name, Gender gender, int age)
        : base("Admin", name, gender, age)
    {
    }
}

public class Moderator : User
{
    public Moderator(string name, Gender gender, int age)
        : base("Moderator", name, gender, age)
    {
    }
}

class Solution
{
    static void Main()
    {
        var adminInput = Console.ReadLine().Split();
        string adminName = adminInput[0];
        Gender adminGender = (Gender)Enum.Parse(typeof(Gender), adminInput[1]);
        int adminAge = int.Parse(adminInput[2]);

        var modInput = Console.ReadLine().Split();
        string modName = modInput[0];
        Gender modGender = (Gender)Enum.Parse(typeof(Gender), modInput[1]);
        int modAge = int.Parse(modInput[2]);

        Admin admin = new Admin(adminName, adminGender, adminAge);
        Moderator moderator = new Moderator(modName, modGender, modAge);

        Console.WriteLine($"Type of user {admin.GetUserName()} is {admin.GetUserType()}");
        Console.WriteLine($"Age of user {admin.GetUserName()} is {admin.GetAge()}");
        Console.WriteLine($"Gender of user {admin.GetUserName()} is {admin.GetGender()}");

        Console.WriteLine($"Type of user {moderator.GetUserName()} is {moderator.GetUserType()}");
        Console.WriteLine($"Age of user {moderator.GetUserName()} is {moderator.GetAge()}");
        Console.WriteLine($"Gender of user {moderator.GetUserName()} is {moderator.GetGender()}");
    }
}