
using EmployeeDepartmentDatabaseApp.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeDepartmentDatabaseApp
{
    class Program
    {
        CompanyContext context;
        public Program()
        {
            context = new CompanyContext();
        }
        void AddDepartment()
        {
            Department department1 = new Department {Name = "HA" };
            Department department2 = new Department { Name = "HR" };
            context.Departments.Add(department1);
            context.Departments.Add(department2);
            context.SaveChanges();
            Console.WriteLine("department created");
        }
        void addEmployee()
        {
            Employee employee = new Employee();
            Console.WriteLine("please enter the employee name");
            employee.Name = Console.ReadLine();
            try
            {
                Console.WriteLine("please enter the employee age");
                employee.Age = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            
            Console.WriteLine("Available department id's are ");
            foreach (var item in context.Departments)
            {
                Console.WriteLine("Department Number " + item.Number);
            }
                Console.WriteLine("please enter the departmentId");
         
            employee.DepartmentNumber = Convert.ToInt32(Console.ReadLine());
            if (!(employee is null))
            { context.Employees.Add(employee);
                context.SaveChanges(); 
            }
        }
        
        void PrintEmployeesDepartmentWise()
        {
            foreach (var item in context.Departments.Include(e=>e.employees))
            {
                Console.WriteLine("Department Number "+item.Number);
                Console.WriteLine("Department Name "+item.Name);
                foreach (var emp in item.employees)
                {
                    Console.WriteLine("-----------Employee Id "+emp.EmployeeId);
                    Console.WriteLine("-----------Employee Name " + emp.Name);
                    Console.WriteLine("-----------Employee Age " + emp.Age);
                }
            }
        }
        void PrintEmployeeInDepartment()
        {
            Console.WriteLine("please enter the departmentId");
            int id = Convert.ToInt32(Console.ReadLine());
            List<Employee> employees = context.Employees.Where(e => e.DepartmentNumber == id).ToList();
            foreach (var item in employees)
            {
                Console.WriteLine("-----------Employee Id " + item.EmployeeId);
                Console.WriteLine("-----------Employee Name " + item.Name);
                Console.WriteLine("-----------Employee Age " + item.Age);
                Console.WriteLine("Department Number " + item.DepartmentNumber);
            }
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            //program.AddDepartment();
            program.PrintEmployeeInDepartment();
            program.addEmployee();
            program.PrintEmployeesDepartmentWise();
            Console.ReadKey();
        }
    }
}
