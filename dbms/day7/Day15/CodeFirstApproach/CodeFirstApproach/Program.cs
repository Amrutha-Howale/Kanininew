using CodeFirstApproach.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeFirstApproach
{
    class Program
    {
        //Program program = new Program();
        pubsContext context;
        public Program()
        {
            
            context = new pubsContext();
        }
        public void GetChoice() { 
        int iChoice = 0;
            do
            {
                Console.WriteLine("Choises available:\n");
                Console.WriteLine("1. Print the list of books by Author\n " +
                    "2. Print all the sales details by Title ID\n" +
                    "3. Choose to exit");
                iChoice = Convert.ToInt32(Console.ReadLine());

                switch (iChoice)
            {
                
                case 1:
                    PrintBooksOfAuthor();
                    break;
                case 2:
                    PrintSalesDetails();
                    break;
                case 3:
                        Console.WriteLine("we are done displaying");
                        break;
                default:
                        Console.WriteLine("Invalid choice. Please try again");
                    break;
            }
} while (iChoice != 3) ;
}
public string getAuthorId()
        {
            Console.WriteLine("Enter Author Name");
            string AuName = Console.ReadLine();
            string au_id = "";
            foreach (var item in context.Authors)
            {
                if (item.AuFname.Equals(AuName)|| item.AuLname.Equals(AuName))
                {
                    au_id = item.AuId;
                    break;
                }


            }
            return au_id;
        }
        public void PrintBooksOfAuthor()

        {

            String authorID = getAuthorId();
            int count = 0;
            Console.WriteLine("Author Id is " + authorID);

            foreach (var item in context.Titleauthors.Include(e => e.Title))
            {
                if (authorID == item.AuId)
                {
                    count++;
                    if (item.TitleId == item.Title.TitleId)
                    {
                        Console.WriteLine("------------------------------");
                        Console.WriteLine("title Id " + item.Title.TitleId);
                        Console.WriteLine("title name " + item.Title.Title1);
                        Console.WriteLine("Title Price " + item.Title.Price);
                        Console.WriteLine("---------------------------------");
                    }

                }


            }
            if (count == 0)
                Console.WriteLine("Author yet to start");


        }

        void PrintSalesDetails()
        {
            Sale sale = new Sale();
            Console.WriteLine("please enter the Title ID");
            string titleId = Console.ReadLine();
            List<Sale> sales = context.Sales.Where(e => e.TitleId == titleId).ToList();
            foreach (var item in sales)
            {
                Console.WriteLine("Store Id " + item.StorId);
                Console.WriteLine("Order Number " + item.OrdNum);
                Console.WriteLine("Title Id " + item.TitleId);
                Console.WriteLine("Order Date " + item.OrdDate);
                Console.WriteLine("PayTerms " + item.Payterms);
                Console.WriteLine("---------------------------------");
            }
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            // program.PrintBooksOfAuthor();
            //program.PrintSalesDetails();
            program.GetChoice();
            Console.ReadKey();
        }
    }
}
