using System;

namespace ArrayOfAccount
{
    class Program
    {
        Bank bank;
        public Program()
        {
            bank = new Bank();
        }
        void PrintMenu()
        {
            int iChoice = 0;
            do
            {
                PrintMenuList();
                iChoice = Convert.ToInt32(Console.ReadLine());
                switch(iChoice)
                {
                    case 0:
                        Console.WriteLine("you have selectec to exit, bye...");
                        break;
                    case 1:
                        bank.AddAccounts();
                        break;
                    case 2:
                        bank.PrintAccountDetails();
                        break;
                    case 3:
                        bank.PrintAccountByNumber();
                        break;
                    case 4:
                        bank.transact();
                        break;
                    case 5:
                        bank.PrintAllTransactions();
                        break;
                    default:
                        Console.WriteLine("invalid choice. please try again");
                        break;
                }
            } while (iChoice != 0);
        }
        void PrintMenuList()
        {
            Console.WriteLine("0: Exit");
            Console.WriteLine("1: Create accounts");
            Console.WriteLine("2: print all account details");
            Console.WriteLine("3: print Details of an account");
            Console.WriteLine("4: Transaction of money");
            Console.WriteLine("5: Print all the transactions");
        }
        static void Main(string[] args)
        {
            new Program().PrintMenu();
            Console.ReadKey();
        }
    }
}
