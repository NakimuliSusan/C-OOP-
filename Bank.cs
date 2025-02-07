using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Susan_s_Banking_System
{
    class Bank
    {

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

            string accountnumber;

            string accountholdername;


            while (true)
            {
                Console.Write("Enter Account Number: ");

                accountnumber = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(accountnumber))
                {
                    Console.WriteLine("Either Account number cannot be empty.");
                    continue;
                }


                break;
            }

            while (true)
            {
                Console.Write("Enter Account Holder Name: ");

                accountholdername = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(accountholdername))
                {
                    Console.WriteLine("Account holder name cannot be empty");
                    continue;
                }
                break;
            }



            Account newAccount = new Account(accountnumber, accountholdername, 0);
            accounts.Add(newAccount);

            Console.WriteLine("Account created successfully!");
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }



        // Method to deposit 
        static void DepositMoney()
        {
            string accountNumber;
            Account account;
            decimal amount;

            while (true) 
            {
                Console.Write("Enter Account Number to Deposit to: ");
                accountNumber = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(accountNumber))
                {
                    Console.WriteLine("Account number cannot be empty.");
                    continue; 
                }

                account = FindAccount(accountNumber);

                if (account == null)
                {
                    Console.WriteLine("Account not found.");
                    continue; 
                }

                break; 
            }

     
           
            while (true)
            {
                Console.Write("Enter amount to deposit: ");
                string amountInput = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(amountInput))
                {
                    Console.WriteLine("Deposit amount cannot be empty");
                    continue;
                }

                if (decimal.TryParse(amountInput, out amount))
                {
                    account.Deposit(amount);
                    break;
                }
              /*  else
                {
                    Console.WriteLine("The amount entered is invalid. Please enter valid amount");
                    continue;

                }*/

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
            string accountNumber;

            while (true) 
            {
                Console.Write("Enter Account Number to View: ");
                accountNumber = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(accountNumber))
                {
                    Console.WriteLine("Account number cannot be empty. Please try again.");
                    continue; 
                }

                break; 
            }

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
            string accountNumber;
            Account account;
            decimal amount;

            while (true)
            {
                Console.Write("Enter Account Number to Withdraw from: ");
                accountNumber = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(accountNumber))
                {
                    Console.WriteLine("Account number cannot be empty.");
                    continue;
                }

                account = FindAccount(accountNumber);

                if (account == null)
                {
                    Console.WriteLine("Account not found.");
                    continue;
                }

                break;
            }



            while (true)
            {
                Console.Write("Enter amount to withdraw: ");
                string amountInput = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(amountInput))
                {
                    Console.WriteLine("Withdraw amount cannot be empty");
                    continue;
                }

                if (decimal.TryParse(amountInput, out amount))
                {
                    account.Withdraw(amount);
                    break;
                }
                /*  else
                  {
                      Console.WriteLine("The amount entered is invalid. Please enter valid amount");
                      continue;

                  }*/

            }

            Console.WriteLine("Press any key to return to the menu......");
            Console.ReadKey();
        }
    }
}
