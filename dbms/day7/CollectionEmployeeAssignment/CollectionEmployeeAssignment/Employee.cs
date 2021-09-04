using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionEmployeeAssignment
{
    class Employee
    {
        int id, age;
        string name;
        double salary;

        public Employee()
        {
        }

        public Employee(int id, int age, string name, double salary)
        {
            this.id = id;
            this.age = age;
            this.name = name;
            this.salary = salary;
        }

        public void TakeEmployeeDetailsFromUser()
        {
            Console.WriteLine("Please enter the employee ID");
            id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the employee Name");
            name = Console.ReadLine();
            Console.WriteLine("Please enter the employee Age");
            age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the employee Salary");
            salary = Convert.ToDouble(Console.ReadLine());
        }

        public override string ToString()
        {
            return  "Employee ID :" +id + "\nName:" +name + "\nAge: " +age +
        "\nSalary: " +salary;
        }

        public int Id
        {
            get => id; set => id = value;
        }
        public int Age
        {
            get => age; set => age = value;
        }
        public string Name
        {
            get => name; set => name = value;
        }
        public double Salary
        {
            get => salary; set => salary = value;
        }
    }
}
