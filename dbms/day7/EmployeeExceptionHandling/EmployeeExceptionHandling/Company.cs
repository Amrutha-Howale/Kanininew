using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeExceptionHandling
{
    public class Company
    {
        Employee[] employees;
        public Company()
        {
            employees = new Employee[5];
        }
        public void AddEmployees()
        {
            try
            {
                for(int i=0;i<6;i++)
                {
                    employees[i] = new Employee();
                    try
                    {
                        Console.WriteLine("please enter the employee id");
                        employees[i].Id = Convert.ToInt32(Console.ReadLine());
                    }
                    catch(FormatException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine("your entry for id is not valid");
                    }
                    Console.WriteLine("please enter the employee name");
                    employees[i].name=Console.ReadLine();
                }
            }
            catch(IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("You tried to access an index that is not present");
            }
        }
        public void PrintEmployees()
        {
            for(int i=0;i<5;i++)
            {
                Console.WriteLine(employees[i]);
            }
        }
    }
}
