using System;
using System.Collections.Generic;
using System.Text;

namespace ArrayOfAccount
{
    public class CurrentAccount:Account
    {
        public CurrentAccount()
        {
            AccountType = "Current";
        }

        public CurrentAccount(string accountNumber, string name, string phone, double balance) : base(accountNumber, name, phone, balance)
        {
            AccountType = "Current";
        }
        public override bool CheckBalanceStatus(double amount)
        {
            bool result = false;
            if(Balance-amount>1000)
            {
                Balance = Balance - amount;
                result = true;
            }
            return result;
        }
    }
}
