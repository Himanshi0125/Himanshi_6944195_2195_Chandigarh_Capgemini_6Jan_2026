using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public interface IBankAccountOperation
{
    decimal Deposit(decimal d);
    decimal Withdraw(decimal d);
    decimal ProcessOperation(string message);
}

public class BankOperations : IBankAccountOperation
{
    decimal balance = 0;

    HashSet<string> depositWords = new HashSet<string>
    { "deposit", "put", "invest", "transfer" };

    HashSet<string> withdrawWords = new HashSet<string>
    { "withdraw", "pull" };

    HashSet<string> showWords = new HashSet<string>
    { "see", "show" };

    public decimal Deposit(decimal d)
    {
        balance += d;
        return balance;
    }

    public decimal Withdraw(decimal d)
    {
        if (balance >= d)
            balance -= d;

        return balance;
    }

    public decimal ProcessOperation(string message)
    {
        message = message.ToLower();

        string[] words = message.Split();

        foreach (string w in words)
        {
            if (depositWords.Contains(w))
            {
                decimal amount = ExtractNumber(message);
                return Deposit(amount);
            }

            if (withdrawWords.Contains(w))
            {
                decimal amount = ExtractNumber(message);
                return Withdraw(amount);
            }

            if (showWords.Contains(w))
            {
                return balance;
            }
        }

        return balance;
    }

    private decimal ExtractNumber(string text)
    {
        var match = Regex.Match(text, @"\d+");

        if (match.Success)
            return decimal.Parse(match.Value);

        return 0;
    }
}

class Solution
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        BankOperations bank = new BankOperations();

        for (int i = 0; i < n; i++)
        {
            string message = Console.ReadLine();

            decimal result = bank.ProcessOperation(message);

            Console.WriteLine(result);
        }
    }
}