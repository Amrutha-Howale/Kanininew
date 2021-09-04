using System;

namespace FirstApplication
{
    class Program
    {
        void Add()
        {
            int num1, num2;
            Console.WriteLine("Enter the first num ");
            num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the second num ");
            num2 = Convert.ToInt32(Console.ReadLine());
            int sum = num1 + num2;
            Console.WriteLine($"The sum of {num1} and {num2} is {sum}");
        }
        void Sub()
        {
            int num1, num2;
            Console.WriteLine("Enter the first num ");
            num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the second num ");
            num2 = Convert.ToInt32(Console.ReadLine());
            int sub = num1 - num2;
            Console.WriteLine($"The difference of {num1} and {num2} is {sub}");
        }
        void Diff()
        {
            int num1, num2;
            Console.WriteLine("Enter the first num ");
            num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the second num ");
            num2 = Convert.ToInt32(Console.ReadLine());
            int diff = num1 / num2;
            Console.WriteLine($"The division of {num1} and {num2} is {diff}");
        }
        void Mul()
        {
            int num1, num2;
            Console.WriteLine("Enter the first num ");
            num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the second num ");
            num2 = Convert.ToInt32(Console.ReadLine());
            int mul = num1 * num2;
            Console.WriteLine($"The multiplication of {num1} and {num2} is {mul}");
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Add();
            program.Sub();
            program.Diff();
            program.Mul();
        //    Console.WriteLine("Hello World!");
        //    Console.WriteLine("Amrutha");
        //    float num1 = float.MaxValue;
        //    Console.WriteLine("The value of num1 is" + num1);
        //    num1 = num1 + 1;
        //    Console.WriteLine("The value of num1 after adding 1 is" + num1);

            //Mobile obj = new Mobile
            //{
            //    Name = "poco",
            //    Price = 15000.32f,
            //    Speed = 123
            //};
            //obj.Call();
            //obj.Printabout();

            //Car car = new Car();
            //car.Name = "KWID";
            //car.Price = 500000;
            //car.MaxSpeed = 120;
            //car.Details();
            Console.ReadKey();
        }
    }
}
