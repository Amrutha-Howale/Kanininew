using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApplication
{
    class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public String Strength { get; set; }
        public DateTime Joindate { get; set; }
        public DateTime RelieveDate { get; set; }
        public string RelieveReason { get; set; }


        public void EmployeeDetails()
        {
            Console.WriteLine("Enter the employee ID");
            Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the employee Name");
            Name = Console.ReadLine();
            Console.WriteLine("Enter the strength of employee ");
            Strength = Console.ReadLine();
        }

        public void AddEmployee()
        {
            Console.WriteLine("EMPLOYEE DETAILS");
            Console.WriteLine("Employee id " + Id);
            Console.WriteLine("Employee Name " + Name);
            Console.WriteLine("Employee id " + Id);
            Console.WriteLine("-----------------------------");
        }

        public void EmployeeReliveDetails()
        {
            //Console.WriteLine("Enter the employee ID");
            //Id = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Enter the employee Name");
            //Name = Console.ReadLine();
            Console.WriteLine("Enter employee join date");
            Joindate =Convert.ToDateTime( Console.ReadLine());
            Console.WriteLine("Enter employee Relive date");
            RelieveDate = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Enter the employee Relieve reason ");
            RelieveReason = Console.ReadLine();
        }

        public void EmployeeRelive()
        {
            Console.WriteLine("EMPLOYEE RELIEVE DETAILS");
            Console.WriteLine("Employee id " + Id);
            Console.WriteLine("Employee Name " + Name);
            Console.WriteLine("Employee join date " + Joindate);
            Console.WriteLine("Employee relive date " + RelieveDate);
            Console.WriteLine("Employee relive reason " + RelieveReason);
        }
    }
}
