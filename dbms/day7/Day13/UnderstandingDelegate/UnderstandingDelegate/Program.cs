using System;

namespace UnderstandingDelegate
{
    class Program
    {
        public delegate void MyDelegate(int num1, int num2);
        public Program()
        {
            //MyDelegate del = delegate (int n1, int n2)
            //{
            //    int sum = n1 + n2;
            //    Console.WriteLine("the sum is " + sum);
            //};
            MyDelegate del = (n1, n2) => Console.WriteLine("the sum is "+(n1+n2));
            del += new MyDelegate(Product);
            CallMethods(del);
        }
        void CallMethods(MyDelegate d)
        {
            d(10, 20);
        }
        void Add(int n1, int n2)
        {
            int sum = n1 + n2;
            Console.WriteLine("The sum is: "+sum);
        }
        void Product(int n1, int n2)
        {
            int product = n1 * n2;
            Console.WriteLine("The product is: " + product);
        }
        static void Main(string[] args)
        {
            new Program();

            Console.ReadKey();
        }
    }
}
