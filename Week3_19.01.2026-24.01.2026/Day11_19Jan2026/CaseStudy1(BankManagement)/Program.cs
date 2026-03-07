using System;

namespace BankManagement
{
    class BankAccount
    {
        private int accountNumber;
        private string accountHolderName;
        protected int balance;

        public BankAccount(int num, string name, int bal)
        {
            accountNumber = num;
            accountHolderName = name;
            balance = bal;
        }

        public void Deposit(int amount)
        {
            if (amount > 0)
            {
                balance += amount;
                Console.WriteLine("Amount Deposited Successfully.");
            }
        }

        public virtual void Withdraw(int amount)
        {
            if (amount <= balance)
            {
                balance -= amount;
                Console.WriteLine("Amount Withdrawn Successfully.");
            }
            else
            {
                Console.WriteLine("Insufficient balance.");
            }
        }

        public void DisplayAccountSummary()
        {
            Console.WriteLine("\n--- Account Summary ---");
            Console.WriteLine("Account Number: " + accountNumber);
            Console.WriteLine("Account Holder: " + accountHolderName);
            Console.WriteLine("Balance: ₹" + balance);
        }
    }

    class SavingsAccount : BankAccount
    {
        private int interestRate = 4;

        public SavingsAccount(int accNo, string name, int balance)
            : base(accNo, name, balance) { }

        public void CalculateInterest()
        {
            int interest = (balance * interestRate) / 100;
            balance += interest;
            Console.WriteLine("Interest added: ₹" + interest);
        }
    }

    class CheckingAccount : BankAccount
    {
        private int overdraftLimit = 5000;

        public CheckingAccount(int accNo, string name, int balance)
            : base(accNo, name, balance) { }

        public override void Withdraw(int amount)
        {
            if (amount > 0 && amount <= balance + overdraftLimit)
            {
                balance -= amount;
                Console.WriteLine("Withdrawal successful (Overdraft allowed).");
            }
            else
            {
                Console.WriteLine("Overdraft limit exceeded.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SavingsAccount savings = new SavingsAccount(101, "Himanshi", 10000);
            savings.Deposit(2000);
            savings.CalculateInterest();
            savings.DisplayAccountSummary();
            Console.WriteLine();

            CheckingAccount checking = new CheckingAccount(102, "Kashish", 5000);
            checking.Withdraw(7000);
            checking.DisplayAccountSummary();

            Console.ReadLine();
        }
    }
}
