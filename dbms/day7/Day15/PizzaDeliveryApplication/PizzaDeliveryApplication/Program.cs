using PizzaDeliveryApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PizzaDeliveryApplication
{
    class Program
    {
        public static float total = 0;
        Pizza_ShopContext pizza_ShopContext;
        int Count = 0;
        Dictionary<int, Pizza> PizzasOrder;
        Dictionary<int, List<Topping>> Mylist;
        int Customer_Id;
        string Address;
        OrderDetail Detail;
        Regex regex;
        Customer customer;
        Order orders;
        ToppingDetail toppingDetail;
        public Program()
        {
            pizza_ShopContext = new Pizza_ShopContext();
            PizzasOrder = new Dictionary<int, Pizza>();
            Mylist = new Dictionary<int, List<Topping>>();
        }
        void StartMenu()
        {
            while (true)
            {
                Console.WriteLine("--------------------------\n1.To Register\n2.To Login\n3.to Exit\n--------------------------");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    if (choice == 1)
                        RegisterUser();
                    else if (choice == 2)
                        Login();
                    else if (choice == 3)
                        break;
                    else
                        Console.WriteLine("Enter Valid Choice");
                }
                else
                    Console.WriteLine("Enter Number only");
            }
        }
        public bool ValidateEmailAddress(string email)
        {
            bool match = false;
            try
            {
                regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", RegexOptions.CultureInvariant | RegexOptions.Singleline);
                return match = regex.IsMatch(email);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return match;
            }
        }
        public bool ValidatePassword(string plainText)
        {
            bool match = false;
            try
            {
                regex = new Regex(@"^(?=.[A-Za-z])(?=.\d)(?=.[@$!%#?&])[A-Za-z\d@$!%*#?&]{8,}$");
                match = regex.IsMatch(plainText);
                return match;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return match;
            }

        }
        public static bool ValidatePhone(string phone)
        {
            bool match = false;
            try
            {
                return match = Regex.IsMatch(phone, "\\A[0-9]{10}\\z");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return match;
            }
        }

        public void RegisterUser()
        {
            customer = new Customer();
            Console.WriteLine("Enter Name of the Customer: ");
            customer.CustName = Console.ReadLine();
            Console.WriteLine("Enter the user Name (Email): ");
            customer.CustEmail = Console.ReadLine();
            bool isValidEmail = ValidateEmailAddress(customer.CustEmail);
            if (!isValidEmail)
            {
                Console.WriteLine("Enter valid Email Id");
            }
            else
            {
                if (pizza_ShopContext.Customers.Where(e => e.CustEmail.ToLower() == customer.CustEmail.ToLower()).Any())
                {
                    Console.WriteLine("Email Id Or Password Already exists");
                    return;
                }
                else
                {

                    Console.WriteLine("Enter the Password: ");
                    customer.CustPassword = Console.ReadLine();
                    //isValidEmail = ValidatePassword(customer.CustPassword);
                    if (!isValidEmail)
                    {
                        Console.WriteLine("Enter valid Password");
                    }
                    else
                    {
                        Console.WriteLine("Enter The Phone Number");
                        customer.CustPhone = Console.ReadLine();
                        bool Validate = ValidatePhone(customer.CustPhone);
                        if (!Validate)
                        {
                            Console.WriteLine("Enter Valid Number");
                        }
                        else
                        {

                            Console.WriteLine("Enter A Valid Address");
                            customer.CustAddress = Console.ReadLine();
                            if (customer.CustAddress.Trim() == "")
                            {
                                Console.WriteLine("Enter Valid Address");
                            }
                            else
                            {
                                pizza_ShopContext.Customers.Add(customer);
                                pizza_ShopContext.SaveChanges();
                                Customer_Id = pizza_ShopContext.Customers.Find(customer.CustEmail).CustId;
                                Address = customer.CustAddress;
                                Console.WriteLine("Registered Successfully");
                                Console.WriteLine("Welcome to ---- Pizza");
                                DisplayPizzaMenu();
                            }
                        }
                    }
                }

            }


        }
        public void Login()
        {
            customer = new Customer();
            Console.WriteLine("Enter Your Email");
            string Email1 = Console.ReadLine();
            Console.WriteLine("Enter Your Password");
            string Pass1 = Console.ReadLine();

            List<Customer> details = pizza_ShopContext.Customers.Where(e => e.CustEmail == Email1 && e.CustPassword == Pass1).ToList();
            bool isEmpty = !details.Any();
            if (isEmpty)
            {
                Console.WriteLine("Invalid input please enter valid Email and Password");
            }
            else
            {
                Console.WriteLine("Welcome to ---- Pizza");
                foreach (var item in details)
                {
                    Customer_Id = item.CustId;
                    Address = item.CustAddress;
                }

                DisplayPizzaMenu();
            }
        }
        public void DisplayPizzaMenu()
        {

            Console.WriteLine("The following are the pizza that are avilable for ordering");
            List<Pizza> pizzas = pizza_ShopContext.Pizzas.ToList();
            foreach (var item in pizzas)
            {
                Console.WriteLine("Pizza id " + item.Id);
                Console.WriteLine("Pizza name " + item.PizzaName);
                Console.WriteLine("Pizza price " + item.Price);
                Console.WriteLine("Pizza type " + item.PizzaType);
                Console.WriteLine("---------------------------------");
            }
            PizzaOrder();
        }
        void PizzaOrder()
        {
            Console.WriteLine("Enter The Pizza Id You Want");
            if (int.TryParse(Console.ReadLine(), out int ID) && pizza_ShopContext.Pizzas.Where(e => e.Id == ID).Any())
            {
                total += Convert.ToInt32(pizza_ShopContext.Pizzas.Find(ID).Price);
                Console.WriteLine($"You Have Selected {pizza_ShopContext.Pizzas.Find(ID).PizzaName} with price: " + total);
                Count += 1;
                PizzasOrder.Add(Count, pizza_ShopContext.Pizzas.Find(ID));
                Console.WriteLine("Do You Want Toppings?(y/n)");
                string c = Console.ReadLine();
                if (c.ToLower() == "y")
                {
                    DisplayToppings();
                }
                else if (c.ToLower() == "n")
                {
                    PizzaMenu();
                }
                else
                {
                    total -= Convert.ToInt32(pizza_ShopContext.Pizzas.Find(ID).Price);
                    PizzasOrder.Remove(Count);
                    Count -= 1;
                    DisplayPizzaMenu();
                }

            }
            else
            {
                Console.WriteLine("Enter Valid Pizza ID");
                DisplayPizzaMenu();
            }
        }
        void DisplayToppings()
        {
            foreach (var item in pizza_ShopContext.Toppings)
            {
                Console.WriteLine("Topping Id: " + item.Id);
                Console.WriteLine("Topping Name: " + item.ToppingsName);
                Console.WriteLine("Topping Price: " + item.Price);
                Console.WriteLine("-----------------------------------");
            }
            Console.WriteLine("Enter The Toppings Id");
            if (int.TryParse(Console.ReadLine(), out int ID) && pizza_ShopContext.Toppings.Where(e => e.Id == ID).Any())
            {
                if (!Mylist.ContainsKey(Count))
                {
                    Mylist[Count] = new List<Topping>() { pizza_ShopContext.Toppings.Find(ID) };
                    total += Convert.ToInt32(pizza_ShopContext.Toppings.Find(ID).Price);
                    Console.WriteLine($"You Have Selected {pizza_ShopContext.Toppings.Find(ID).ToppingsName} with price {pizza_ShopContext.Toppings.Find(ID).Price} and total: " + total);
                    ExtraToppings();
                }
                else
                {
                    if (Mylist[Count].Contains(pizza_ShopContext.Toppings.Find(ID)))
                    {
                        Console.WriteLine("Topping Already Added");
                        ExtraToppings();
                    }
                    else
                    {
                        Mylist[Count].Add(pizza_ShopContext.Toppings.Find(ID));
                        total += Convert.ToInt32(pizza_ShopContext.Toppings.Find(ID).Price);
                        Console.WriteLine($"You Have Selected {pizza_ShopContext.Toppings.Find(ID).ToppingsName} with price {pizza_ShopContext.Toppings.Find(ID).Price} and total: " + total);
                        ExtraToppings();
                    }
                }

            }
            else
            {
                Console.WriteLine("Enter Valid Toppings ID");
                DisplayToppings();
            }
        }
        void ExtraToppings()
        {
            Console.WriteLine("Do You Want More Toppings?(y/n)");
            string c = Console.ReadLine();
            if (c.ToLower() == "y")
            {
                DisplayToppings();
            }

            else if (c.ToLower() == "n")
            {
                PizzaMenu();
            }
            else
            {
                Console.WriteLine("Enter valid Input");
                ExtraToppings();
            }
        }
        void PizzaMenu()
        {
            Console.WriteLine("Do You Want Order One More Pizza?y/n");
            string cc = Console.ReadLine();
            if (cc.ToLower() == "y")
            {
                DisplayPizzaMenu();
            }
            else if (cc.ToLower() == "n")
            {
                total = total <= 500 ? total += 25 : total;
                orders = new Order() { TotalPrice = total, CustId = Customer_Id, DeliveryAddress = Address, OrderDate = DateTime.Today };
                try
                {
                    pizza_ShopContext.Orders.Add(orders);
                    pizza_ShopContext.SaveChanges();
                    List<Order> Order_Id = pizza_ShopContext.Orders.Where(e => e.CustId == Customer_Id).ToList();
                    int OID = Order_Id[^1].OrderId;
                    foreach (var item in PizzasOrder.Keys)
                    {
                        Console.WriteLine(PizzasOrder[item]);
                        Detail = new OrderDetail() { OrderId = OID, PizzaId = PizzasOrder[item].Id, Qty = 1 };
                        pizza_ShopContext.OrderDetails.Add(Detail);
                        pizza_ShopContext.SaveChanges();
                        if (Mylist.ContainsKey(item))
                        {

                            Console.WriteLine("You Have Selected Following Toppings");
                            foreach (var items in Mylist[item])
                            {
                                toppingDetail = new ToppingDetail();
                                List<OrderDetail> orderDetail = pizza_ShopContext.OrderDetails.Where(e => e.OrderId == OID).ToList();
                                int Order_DetailsID = orderDetail[^1].Id;
                                toppingDetail.DetailsId = Order_DetailsID;
                                toppingDetail.ToppingsId = items.Id;
                                pizza_ShopContext.ToppingDetails.Add(toppingDetail);
                                pizza_ShopContext.SaveChanges();
                                Console.WriteLine("-----------------------------------");
                                Console.WriteLine("Topping Id: " + items.Id);
                                Console.WriteLine("Topping Name: " + items.ToppingsName);
                                Console.WriteLine("Topping Price" + items.Price);
                                Console.WriteLine("------------------------------------");
                            }
                        }
                        else
                            Console.WriteLine("No Toppings Selected For the Pizza");
                    }
                    Console.WriteLine("Order Placed Successfully");
                    Console.WriteLine("Your total Price is " + total);
                    Console.WriteLine("Your Order Will Be Delivered to: " + orders.DeliveryAddress);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }


            }
            else
                PizzaMenu();
        }
        static void Main(string[] args)
        {
            new Program().StartMenu();
            Console.ReadKey();
        }

    }
}