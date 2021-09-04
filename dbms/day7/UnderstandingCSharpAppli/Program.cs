using System;

namespace UnderstandingCSharpAppli
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
            switch (choice)
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
            void UnderstandingWhile()
            {
                int num = 10;
                while(num<100)
                {
                    Console.WriteLine("the num is " + num);
                    Console.WriteLine("Change the num");
                    num = Convert.ToInt32(Console.ReadLine());
                }
            }
        void UnderstandingDoWhile()
        {
            int num;
            do
            {
                Console.WriteLine("Change the num");
                num = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("The number is " + num);
            } while (num < 100); 
        }
        void UnderstandingCSharpFeatures()
        {
            int iNum1 = int.MaxValue;
            /*checked
            {
                Console.WriteLine(iNum1);
                iNum1++;
                Console.WriteLine(iNum1);
            }*/
            Console.WriteLine("please enter a num");
            //bool res = int.TryParse(Console.ReadLine(), out iNum1);
            //if (res == true)
            //    Console.WriteLine("you have entered" + iNum1);
            //else
            //    Console.WriteLine("the result is " + iNum1);
            //while(!int.TryParse(Console.ReadLine(),out iNum1))
            //{
            //    Console.WriteLine("invalid entry , please enter agin");
            //}
            //Console.WriteLine("you have entered " + iNum1);
            int? iNum2 = 100;
            iNum1 = iNum2 ?? 10;
            Console.WriteLine($"The value is {iNum2}");
              
        }
        void UnderstandingArray()
        {
            int[] numbers = { 20, 30, 40, 50, 60 };
            Console.WriteLine("the size of the array is " + numbers.Length);
            for(int i=0;i<numbers.Length;i++)
            {
                Console.WriteLine(numbers[i]);
            }
           // Console.WriteLine("the 6th position number is " + numbers[5]);
        }

        void LearningStringArray()
        {
            String[] names = new string[5];
            for(int i=0;i<names.Length;i++)
            {
                Console.WriteLine($"please enter name {i + 1}");
                names[i] = Console.ReadLine();
            }
            for(int i=0;i<names.Length-1;i++)
            {
                Console.WriteLine(names[i]+" ,");
            }
            Console.WriteLine(names[names.Length - 1]);
        }

        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //new Program().UnderstandingIf();
            //new Program().UnderstandingSwitch();
            //new Program().UnderstandingWhile();
            //new Program().UnderstandingCSharpFeatures();
            //new Program().UnderstandingArray();
            new Program().LearningStringArray();
            //Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
