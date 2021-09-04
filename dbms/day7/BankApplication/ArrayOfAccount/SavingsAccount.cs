using System;
using System.Collections.Generic;
using System.Text;

namespace ArrayOfAccount
{
    public class SavingsAccount:Account
    {
        public SavingsAccount()
        {
            AccountType = "Savings";
        }

        public SavingsAccount(string accountNumber, string name, string phone, double balance) : base(accountNumber, name, phone, balance)
        {
            AccountType = "Savings";
        }
        public override bool CheckBalanceStatus(double amount)
        {
            bool result = false;
            if (Balance - amount > 5000)
            {
                Balance = Balance - amount;
                result = true;
            }
            return result;
        }
    }
}
