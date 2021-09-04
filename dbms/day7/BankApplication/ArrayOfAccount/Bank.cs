using System;
using System.Collections.Generic;
using System.Text;

namespace ArrayOfAccount
{
    public class Bank
    {
        //Account[] accounts;
        List<Account> accounts;
        //Transaction[] transactions;
        List<Transaction> transactions;
        int MAX_SIZE = 5;
        int count,transCount;
        public Bank()
        {
            //accounts = new Account[5];
            accounts = new List<Account>();
            //transactions = new Transaction[5];
            transactions = new List<Transaction>();
            count = 0;
            transCount = 0;
        }
        public void AddAccounts()
        {
            string typeChoice;
            do
            {
                Console.WriteLine("Do you want to open a savings or current account");
                Console.WriteLine("key in 's' for savings and 'c' for current");
                Console.WriteLine("Key in e to exit");
                typeChoice = Console.ReadLine().ToLower();
                switch (typeChoice)
                {
                    case "s":
                        accounts.Add(new SavingsAccount());
                        break;
                    case "c":
                        accounts.Add(new CurrentAccount());
                        break;
                    case "e":
                        Console.WriteLine("we are done creating accounts");
                        break;
                    default:
                        Console.WriteLine("Ïnvalid option, please try again");
                        break;
                }
                if (typeChoice=="s" || typeChoice=="c")
                {
                    //accounts[count].GetAccountDetailsFromUser();
                    accounts[accounts.Count - 1].GetAccountDetailsFromUser();
                    count++;
                }
                else
                    continue;
            } while (typeChoice!="e");
        }
        public void PrintAccountByNumber()
        {
            string userAccountNumber = GetAccountNumberFromUser();
            Account account = GetAccountUsingNumber(userAccountNumber);
            if(account==null)
            {
                Console.WriteLine($"invalid account number {userAccountNumber}. no account present with this name");
                return;
            }
            PrintAccount(account);
        }
        Account GetAccountUsingNumber(string accountNumber)
        {
            Account account = null;
            for (int i = 0; i < count; i++)
            {
                if(accounts[i].AccountNumber==accountNumber)
                {
                   /* try
                    {
                        account = accounts[i];
                    }
                    catch (FormatException e)
                    {

                        Console.WriteLine(e.Message);
                        Console.WriteLine("your entry for id is not valid");
                    }*/
                    account = accounts[i];
                    break;
                }
            }
            return account;
        }
        string GetAccountNumberFromUser()
        {
            //Console.WriteLine("please enter the account number");
            string accNumber = Console.ReadLine();
            if(accNumber==" " || accNumber==null )
            {
                Console.WriteLine("something went wrong. please try again");
                GetAccountNumberFromUser();
            }
            return accNumber;
        }
        public void PrintAccountDetails()
        {
            //for(int i=0;i<count;i++)
            //{
            //    PrintAccount(accounts[i]);
            //}
            foreach (var item in accounts)
            {
                PrintAccount(item);
            }
        }
        public void PrintAccount(Account account)
        {
            Console.WriteLine("------------------------");
            Console.WriteLine(account);
            Console.WriteLine("------------------------");
        }
        public void transact()
        {
            Transaction transaction = new Transaction();
            Console.WriteLine("please enter the from account number");
            string fromAccount = GetAccountNumberFromUser();
            transaction.FromAccount = GetAccountUsingNumber(fromAccount);
            if(transaction.FromAccount==null)
            {
                Console.WriteLine("invalid from account");
                return;
            }
            Console.WriteLine("please enter the to account number");
            string toAccount = GetAccountNumberFromUser();
            transaction.ToAccount = GetAccountUsingNumber(toAccount);
            if (transaction.ToAccount == null)
            {
                Console.WriteLine("invalid to account");
                return;
            }
            transaction.TransactionDate = DateTime.Today;
            Console.WriteLine("please enter if it is credit or debit");
            string type = Console.ReadLine().ToLower();
            if (type == "credit")
            {
                CreditTransaction(transaction);
            }
            //transactions[transCount] = transaction;
            transactions.Add(transaction);
            transCount++;
        }
        void CreditTransaction(Transaction transaction)
        {
            transaction.Type = "credit";
            Console.WriteLine("please enter the amount");
            double amount = Convert.ToDouble(Console.ReadLine());
            transaction.Amount = amount;
            if(transaction.FromAccount.CheckBalanceStatus(amount))
            {
                transaction.ToAccount.Balance += amount;
                Console.WriteLine("----------------------------");
                Console.WriteLine("Printing updated balance of from account");
                PrintAccount(transaction.FromAccount);
                transaction.Status = "Success";
            }
            else
            {
                Console.WriteLine("Insufficient balance.Transaction failed");
                transaction.Status = "Failed due to lack of balance";
            }
            Console.WriteLine("--------------------");
            Console.WriteLine("The transaction details");
            Console.WriteLine(transaction);
            //transaction.Id = transCount + 1;
            transaction.Id = transactions.Count + 1;
        }
        public void PrintAllTransactions()
        {
            //for (int i = 0; i < transCount; i++)
            //{
            //    Console.WriteLine("******************");
            //    Console.WriteLine(transactions[i]);
            //    Console.WriteLine("******************");
            //}
            foreach (var item in transactions)
            {
                Console.WriteLine(item);
            }
        }
    }
}
