using System;
using System.Collections.Generic;
using System.Linq;

public interface IUser
{
    int Id { get; set; }
    string Email { get; set; }
    string Password { get; set; }
    string Location { get; set; }
    int IncorrectAttempt { get; set; }
}

public class User : IUser
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Location { get; set; }
    public int IncorrectAttempt { get; set; }

    public User(int id, string email, string password, string location)
    {
        Id = id;
        Email = email;
        Password = password;
        Location = location;
        IncorrectAttempt = 0;
    }
}

public interface IApplicationAuthState
{
    string Register(IUser user);
    string Login(IUser user);
    string Logout(IUser user);
}

public class ApplicationAuthState : IApplicationAuthState
{
    public List<string> AllowedLocations { get; set; }
    public List<IUser> RegisteredUsers { get; set; }
    public List<IUser> UsersLoggedIn { get; set; }

    public ApplicationAuthState(List<string> allowedLocations)
    {
        AllowedLocations = allowedLocations;
        RegisteredUsers = new List<IUser>();
        UsersLoggedIn = new List<IUser>();
    }

    public string Register(IUser user)
    {
        var existing = RegisteredUsers.FirstOrDefault(u => u.Email == user.Email);

        if (existing != null)
            return $"{user.Email} is already registered!";

        RegisteredUsers.Add(user);
        return $"{user.Email} registered successfully!";
    }

    public string Login(IUser user)
    {
        var registered = RegisteredUsers.FirstOrDefault(u => u.Email == user.Email);

        if (registered == null)
            return $"{user.Email} is not registered!";

        if (registered.IncorrectAttempt >= 3)
            return $"{user.Email} is blocked!";

        if (!AllowedLocations.Contains(user.Location))
            return $"{user.Email} is not allowed to login from this location!";

        var logged = UsersLoggedIn.FirstOrDefault(u => u.Email == user.Email);

        if (logged != null)
        {
            if (logged.Location != user.Location)
                return $"{user.Email} is already logged in from another location!";

            return $"{user.Email} is already logged in!";
        }

        if (registered.Password != user.Password)
        {
            registered.IncorrectAttempt++;
            return $"{user.Email} password is incorrect!";
        }

        registered.IncorrectAttempt = 0;
        registered.Location = user.Location;

        UsersLoggedIn.Add(registered);

        return $"{user.Email} logged in successfully!";
    }

    public string Logout(IUser user)
    {
        var logged = UsersLoggedIn.FirstOrDefault(u => u.Email == user.Email);

        if (logged == null)
            return $"{user.Email} is not logged in!";

        UsersLoggedIn.Remove(logged);

        return $"{user.Email} logged out successfully!";
    }
}

class Solution
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        List<string> allowedLocations = new List<string>();

        for (int i = 0; i < n; i++)
            allowedLocations.Add(Console.ReadLine());

        ApplicationAuthState app = new ApplicationAuthState(allowedLocations);

        int m = int.Parse(Console.ReadLine());

        List<IUser> users = new List<IUser>();

        for (int i = 0; i < m; i++)
        {
            var data = Console.ReadLine().Split(',');

            int id = int.Parse(data[0]);
            string email = data[1];
            string password = data[2];
            string location = data[3];

            users.Add(new User(id, email, password, location));
        }

        int k = int.Parse(Console.ReadLine());

        for (int i = 0; i < k; i++)
        {
            var op = Console.ReadLine().Split(':');

            string command = op[0];
            int index = int.Parse(op[1]);

            IUser user = users[index];

            if (command == "Register")
                Console.WriteLine(app.Register(user));
            else if (command == "Login")
                Console.WriteLine(app.Login(user));
            else if (command == "Logout")
                Console.WriteLine(app.Logout(user));
        }
    }
}