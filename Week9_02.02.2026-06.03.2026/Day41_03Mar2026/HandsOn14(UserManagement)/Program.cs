using System;
using System.Collections.Generic;
using System.Linq;

class User
{
    public int Id;
    public string Data;

    public User(int id, string data)
    {
        Id = id;
        Data = data;
    }
}

static class UserManager
{
    public static (List<User> updated, List<User> inserted) CompareUsers(
        List<User> usersListInDB,
        List<User> newUsersList)
    {
        List<User> updated = new List<User>();
        List<User> inserted = new List<User>();

        foreach (var user in newUsersList)
        {
            if (user.Id == 0)
            {
                inserted.Add(user);
                continue;
            }

            var dbUser = usersListInDB.FirstOrDefault(u => u.Id == user.Id);

            if (dbUser != null)
            {
                if (dbUser.Data != user.Data)
                {
                    updated.Add(user);
                }
            }
        }

        return (updated, inserted);
    }
}

class Solution
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        List<User> usersListInDB = new List<User>();

        for (int i = 0; i < n; i++)
        {
            string line = Console.ReadLine();
            var parts = line.Split(',');

            int id = int.Parse(parts[0]);
            string data = string.Join(",", parts.Skip(1));

            usersListInDB.Add(new User(id, data));
        }

        int m = int.Parse(Console.ReadLine());

        List<User> newUsersList = new List<User>();

        for (int i = 0; i < m; i++)
        {
            string line = Console.ReadLine();
            var parts = line.Split(',');

            int id = int.Parse(parts[0]);
            string data = string.Join(",", parts.Skip(1));

            newUsersList.Add(new User(id, data));
        }

        var result = UserManager.CompareUsers(usersListInDB, newUsersList);

        Console.WriteLine("Updated Users:" + result.updated.Count);
        Console.WriteLine("Inserted Users:" + result.inserted.Count);
    }
}