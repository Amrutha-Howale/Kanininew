using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApplication
{
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        public DateTime DOB { get; set; }
        void GetEmployeeDetails()
        {
            Console.WriteLine("Enter the employee ID");
            Id = Convert.ToInt32( Console.ReadLine());
            Console.WriteLine("Enter the employee Name");
            Name =Console.ReadLine();
            Console.WriteLine("Enter the employee Salary");
            Salary = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the employee DOB");
            DOB = Convert.ToDateTime(Console.ReadLine());
        }
        void PrintEmployeeDetails()
        {
            Console.WriteLine("Employee id " + Id);
            Console.WriteLine("Employee Name " + Name);
            Console.WriteLine("Employee salary " + Salary);
            Console.WriteLine("Employee DOB " + DOB);
        }
        static void Main(String[] arr)
        {
            Employee emp1 = new Employee();
            emp1.GetEmployeeDetails();
            emp1.PrintEmployeeDetails();
            Console.WriteLine("Employee class");
            Console.ReadKey();
        }
    }
}
