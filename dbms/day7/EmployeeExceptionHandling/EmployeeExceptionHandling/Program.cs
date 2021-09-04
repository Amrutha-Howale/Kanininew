using System;

namespace EmployeeExceptionHandling
{
    class Program
    {
        int check()
        {
            int num1 = 100;
            int num2 = 10;
            try
            {
                int result = num1 / num2;
                Console.WriteLine(result);
                return result;
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("always");
            }
            Console.WriteLine("all done");
            return 0;
        }
        static void Main(string[] args)
        {
            /* 
             Company comp = new Company();
             comp.AddEmployees();
             comp.PrintEmployees();*/
            Program program = new Program();
            program.check();
            Console.ReadKey();
        }
    }
}
