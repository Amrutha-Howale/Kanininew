using System;
using System.Collections.Generic;
using System.Linq;

namespace EFExampleProject
{
    class Program
    {
        CompanyContext context;
        public Program()
        {
            context = new CompanyContext();
        }
        void GetAllEmployeeFromDatabase()
        {
            List<Employee> employees = context.employees.ToList();
            foreach (var item in employees)
            {
                Console.WriteLine("Employee id "+item.Id);
                Console.WriteLine("Employee name " + item.Name);
                Console.WriteLine("Employee age " + item.Age);
                Console.WriteLine("---------------------------------");
            }
        }
        void AddEmployee()
        {
            Employee employee = new Employee();
            Console.WriteLine("please enter the employee name");
            employee.Name = Console.ReadLine();
            Console.WriteLine("please enter the employee age");
            employee.Age =Convert.ToInt32( Console.ReadLine());
            context.employees.Add(employee);
            context.SaveChanges();
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.AddEmployee();
            program.GetAllEmployeeFromDatabase();
        }
    }
}
