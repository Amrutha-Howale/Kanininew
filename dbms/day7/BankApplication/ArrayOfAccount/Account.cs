using System;
using System.Collections.Generic;
using System.Text;

namespace ArrayOfAccount
{
    public class Account
    {
        public string AccountNumber { get; set; }
        public string Name { get; set; }
        public string AccountType { get; set; }
        public string Phone { get; set; }
        public double Balance { get; set; }

        public Account()
        {
            Balance = 5000;
        }
        public override bool Equals(object obj)
        {
            Account a1 = this;
            Account a2 = (Account)obj;
            if (a1.AccountNumber == a2.AccountNumber)
                return true;
            else
                return false;
        }

        public Account(string accountNumber, string name, string phone, double balance )
        {
            AccountNumber = accountNumber;
            Name = name;
            Balance = balance;
            Phone = phone;
        }

       public void GetAccountDetailsFromUser()
        {
           
                AccountNumber = null;
                Console.WriteLine("please enter the account number");
                AccountNumber = Console.ReadLine();
                Console.WriteLine("please enter the account holder's number");
                Name = Console.ReadLine();
                Console.WriteLine("please enter the contact phone number");
                Phone = Console.ReadLine();
                Console.WriteLine("please enter the initial balance");
            try
            {
                Balance = double.Parse(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public override string ToString()
        {
            return "Account number : " + AccountNumber
                    + "\n Name :" + Name
                    + "\nAccount Type : " + AccountType
                    + "\nAccount holder's name : " + Name
                    + "\nCurrent Balance : " + Balance
                    + "\nContact Number : " + Phone;
        }
        public virtual bool CheckBalanceStatus(double amount)
        {
            bool result = false;
            return result;
        }

    }
}

