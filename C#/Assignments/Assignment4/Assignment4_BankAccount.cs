using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4_BankAccount
{
    class InsuffientBalanceException : Exception
    {
        public InsuffientBalanceException(string message) : base(message)
        {

        }
    }
    public class bankaccount
    {
        private double amount;
        private double balance;

        public bankaccount(double balance)
        {
            this.balance = balance;
            Console.WriteLine("Initial balance: " + balance);
        }

        public void Deposit(double amount1)
        {
            balance += amount1;
            Console.WriteLine("Amount to be deposited: " + amount1);
            Console.WriteLine("New balance: " + balance);
        }

        public void Withdraw(double amount)
        {
            if (amount > balance)
            {
                throw (new InsuffientBalanceException("Insufficient balance"));
            }
            balance -= amount;
            Console.WriteLine("Amount to be withdrawn: " + amount);
            Console.WriteLine("New balance: " + balance);
        }

        public void CheckBalance()
        {
            Console.WriteLine("Current balance: " + balance);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            bankaccount ba = new bankaccount(50000);
            try
            {
                Console.WriteLine("Enter the amount to be deposited");
                double amount1 = Convert.ToDouble(Console.ReadLine());
                ba.Deposit(amount1);
                Console.WriteLine("Enter the amount to be withdrawn");
                double amount2 = Convert.ToDouble(Console.ReadLine());
                ba.Withdraw(amount2);
                ba.CheckBalance();
                Console.WriteLine();
                Console.WriteLine("Exception Handling");
                Console.WriteLine("Enter the amount to be withdrawn:");
                double amount3 = Convert.ToDouble(Console.ReadLine());
                ba.Withdraw(amount3);
            }
            catch (InsuffientBalanceException ie)
            {
                Console.WriteLine(ie.Message + " " + "so transaction is declined");
            }

        }
    }
}
