using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3_BankAccount
{
    public class bankaccount
    {
        private int accountno;
        private string customername;
        private string accounttype;
        private string transactiontype;
        private double amount;
        private double balance;

        public bankaccount(int accountno, string customername, string accounttype, double balance)
        {
            this.accountno = accountno;
            this.customername = customername;
            this.accounttype = accounttype;
            this.balance = balance;
        }

        public void UpdateBalance(string transactiontype, int amount)
        {
            this.transactiontype = transactiontype;
            this.amount = amount;

            if (transactiontype == "D")
            {
                Credit(amount);
            }
            if (transactiontype == "W")
            {
                Debit(amount);
            }
        }

        public void Credit(int amount)
        {
            balance += amount;
        }

        public void Debit(int amount)
        {
            if (amount <= balance)
                balance -= amount;
            else
                Console.WriteLine("Insufficient balance");
        }

        public void showdata()
        {
            Console.WriteLine("Account Number: " + accountno);
            Console.WriteLine("Customer Name: " + customername);
            Console.WriteLine("Account Type: " + accounttype);
            Console.WriteLine("Transaction type: " + transactiontype);
            Console.WriteLine("Balance: " + balance);
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            bankaccount ba = new bankaccount(2468, "Priya", "Savings", 50000);
            ba.UpdateBalance("D", 5000);
            ba.showdata();
            Console.WriteLine();

            ba.UpdateBalance("W", 10000);
            ba.showdata();
        }
    }
}