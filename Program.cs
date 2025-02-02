// See https://aka.ms/new-console-template for more information
// Banking System Console App
using System;
using System.Collections.Generic; // Important for storing accounts

class Bank
{

    public class Account
    {
        public string AccountNumber { get; set; }
        public string AccountHolderName { get; set; }
        public decimal Balance { get; set; }

        public Account(string accountNumber, string accountHolderName, decimal balance)
        {

            AccountNumber = accountNumber;

            AccountHolderName = accountHolderName;

            Balance = balance;

        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Please enter an amount greater than 0");
            }
            else
            {
                Balance += amount;
                Console.WriteLine($"{amount} UGX has been deposited into {AccountNumber}");
            }
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Please enter an amount greater than 0");
            }
            else if (amount >= Balance)
            {
                Console.WriteLine($"Insufficient account balance. Your account balance is {Balance} UGX.Ensure to leave a service charge");
            }
            else
            {
                Balance -= amount;
                Console.WriteLine($"{amount} UGX has been withdrawn successfully from {AccountNumber}. Your account balance is {Balance} UGX");
            }
        }

        public void DisplayAccountDetails()
        {
            Console.WriteLine($"Account {AccountNumber} belonging to {AccountHolderName} has available balance {Balance} UGX"); // Improved wording
        }
    }

    // List to store all accounts
    static List<Account> accounts = new List<Account>();

    static void Main(string[] args)
    {
        // bool running = true;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Susan's Bank System!\r\n");
            Console.WriteLine("1. Create Account");
            Console.WriteLine("2. Deposit Money");
            Console.WriteLine("3. Withdraw Money");
            Console.WriteLine("4. View Account Details");
            Console.WriteLine("5. View All Accounts");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            //Menu to select different choices
            switch (choice)
            {
                case "1":
                    CreateAccount();
                    break;
                case "2":
                    DepositMoney();
                    break;
                case "3":
                    WithdrawMoney();
                    break;
                case "4":
                    ViewAccountDetails();
                    break;
                case "5":
                    ViewAllAccounts();
                    break;
                case "6":
                    break;
                default:
                    // Console.WriteLine("Invalid choice. Try again.");
                    continue;
            }

        }
    }

    // Method to create an account
    static void CreateAccount()
    {
        Console.Write("Enter Account Number: ");
        string accountNumber = Console.ReadLine();
        Console.Write("Enter Account Holder Name: ");
        string accountHolderName = Console.ReadLine();




        // Creating a new account instance
        Account newAccount = new Account(accountNumber: accountNumber, accountHolderName, balance: 0) { };
        accounts.Add(newAccount);

        Console.WriteLine("Account created successfully!");

        Console.WriteLine("Press any key to return to the menu...");

        Console.ReadKey();
    }

    // Method to deposit 
    static void DepositMoney()
    {
        Console.Write("Enter Account Number to Deposit to: ");
        string accountNumber = Console.ReadLine();

        Account account = FindAccount(accountNumber);

        if (account != null)
        {
            Console.Write("Enter amount to deposit: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                account.Deposit(amount);
            }
            else
            {
                Console.WriteLine("Invalid amount.");
            }
        }
        else
        {
            Console.WriteLine("Account not found.");
        }
        Console.WriteLine("Press any key to return to the menu......");

        Console.ReadKey();
    }

    // Finding an account to enable knowing in which account to deposit and withdraw
    static Account FindAccount(string accountNumber)
    {
        foreach (Account account in accounts)
        {
            if (account.AccountNumber == accountNumber)
            {
                return account;
            }
        }
        return null;
    }

    // Method to view all accounts
    static void ViewAllAccounts()
    {
        if (accounts.Count == 0)
        {
            Console.WriteLine("No accounts have been created yet.");
        }
        else
        {
            Console.WriteLine("List of all accounts:");
            foreach (Account account in accounts)
            {
                account.DisplayAccountDetails();
            }
        }
        Console.WriteLine("Press any key to return to the menu...");

        Console.ReadKey();
    }


    // Method to view account details
    static void ViewAccountDetails()
    {
        Console.Write("Enter Account Number to View: ");

        string accountNumber = Console.ReadLine();

        Account account = FindAccount(accountNumber);

        if (account != null)
        {
            account.DisplayAccountDetails();
        }
        else
        {
            Console.WriteLine("Account not found.");
        }
        Console.WriteLine("Press any key to return to the menu...");

        Console.ReadKey();
    }


    // Withdraw money from any account
    static void WithdrawMoney()
    {
        Console.Write("Enter Account Number to Withdraw From: ");
        string accountNumber = Console.ReadLine();

        Account account = FindAccount(accountNumber);

        if (account != null)
        {
            Console.Write("Enter amount to Withdraw: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                account.Withdraw(amount);
            }
            else
            {
                Console.WriteLine("Invalid amount.");
            }
        }
        else
        {
            Console.WriteLine("Account not found.");
        }
        Console.WriteLine("Press any key to return to the menu...");

        Console.ReadKey();
    }
}






















