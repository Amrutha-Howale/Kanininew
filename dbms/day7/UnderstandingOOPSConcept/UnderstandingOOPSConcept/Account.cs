using System;
using System.Collections.Generic;
using System.Text;

namespace UnderstandingOOPSConcept
{
    public class Account
    {
        public float Balance { get; set; }
        public bool IdProof { get; set; }
        public string Name { get; set; }
        public Account()
        {
            Console.WriteLine("default constructor");
        }
        public Account(string name)
        {
            Name = name;
        }
        public void CreateAccount(float amount)
        {
            Balance = amount;
            IdProof = false;
        }
        public void CreateAccount(float amount,string idproof)
        {
            Balance = amount;
            Console.WriteLine($"the id proof is { idproof} and amount is {Balance}");
            IdProof = true;
        }
        public static Account operator +(Account a1,Account a2)
        {
            Account account = new Account();
            account.Balance = a1.Balance + a2.Balance;
            return account;
        }
    }
}
