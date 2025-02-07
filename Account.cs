using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Susan_s_Banking_System
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
            Console.WriteLine($"Account {AccountNumber} belonging to {AccountHolderName} has available balance {Balance} UGX"); 
        }
    }
}
