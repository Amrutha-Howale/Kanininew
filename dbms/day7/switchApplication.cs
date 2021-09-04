using System;

namespace ApplicationToUnderstandC
{
    class Program
    {
        void UnderstandingIf()
        {
            Console.WriteLine("Please enter number");
            int num1 = Convert.ToInt32(Console.ReadLine());
            if (num1 > 100)
            {
                Console.WriteLine("Good");
                Console.WriteLine("Line 2");
            }
            else
                Console.WriteLine("ok");
        }

        void UnderstandingSwitch()
        {
            Console.WriteLine("please enter a day");
            string choice = Console.ReadLine();
            switch(choice)
            {
                case "Monday":
                    Console.WriteLine();
                    break;
                case "Tuesday":
                    Console.WriteLine();
                    break;
                case "Wednesday":
                    Console.WriteLine();
                    break;
                case "Friday":
                    Console.WriteLine("last working day");
                    break;
                case "Saturday":
                    break;
                case "Sunday":
                    Console.WriteLine("weekend");
                    break;
                default:
                    Console.WriteLine("invalid");
                    break;
            }
        }
        static void Main(string[] args)
        {
            new Program().UnderstandingIf();
            new Program().UnderstandingSwitch();
            //Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
