using ProductListingAndStoringApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductListingAndStoringApp
{
    class Program
    {
        readonly ProductDetailsContext Context;
        public Program()
        {
            Context = new ProductDetailsContext();
        }
        public void GetChoice()
        {
            int IChoice;
            try
            {
                do
                {
                    Console.WriteLine("1. List All Items\n " +
                        "2. Add Products\n"+"3.Exit\n");
                    Console.WriteLine("Please enter your choice");

                    IChoice = Convert.ToInt32(Console.ReadLine());

                    switch (IChoice)
                    {
                        case 1:
                            PrintAllItems();
                            break;
                        case 2:
                            AddProducts();
                            break;
                        case 3:
                            Console.WriteLine("We are done adding and displaying");
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again");
                            break;
                    }
                } while (IChoice != 3);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                GetChoice();
            }

        }
        public void PrintAllItems()
        {
            List<Product> items = Context.Products.ToList();
            foreach (var products in items)
            {
                Console.WriteLine("The Item details:");
                Console.WriteLine("             Product id " + products.ProdId);
                Console.WriteLine("             Product name " + products.ProdName);
                Console.WriteLine("             Product Price " + products.ProdPrice);
                Console.WriteLine("             Product Quantity " + products.Quantity);
                Console.WriteLine("---------------------------------");
            }

        }
        public void AddProducts()
        {
            Product product = new Product();
            Console.WriteLine("please enter the product id");
            product.ProdId = Convert.ToInt32( Console.ReadLine());
            Console.WriteLine("please enter the product Name");
            product.ProdName = Console.ReadLine();
            Console.WriteLine("please enter the product Price");
            product.ProdPrice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("please enter the product Quantity");
            product.Quantity = Convert.ToInt32(Console.ReadLine());
            Context.Products.Add(product);
            Context.SaveChanges();
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.GetChoice();
        }
    }
}
