using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace CollectionEmployeeAssignment
{
    /// <summary>
    /// IComparable interface is used in employee class
    /// </summary>
    class Employee:IComparable<Employee>
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
        public override bool Equals(object obj)
        {
            Employee e1,e2;
            e1 = this;
            e2 = (Employee)obj;
            if (e1.Id == e2.Id)
                return true;
            else
                return false;

        }

        public override string ToString()
        {
            return  "Employee ID :" +id + "\nName:" +name + "\nAge: " +age +
        "\nSalary: " +salary;
        }

        /// <summary>
        /// ICpmarable operator is overloaded and compareTo is used to compair which other employees salary 
        /// </summary>
        /// <param name="other"></param>
        /// <returns>sorted elmployee list according to salary</returns>
        public int CompareTo(Employee other)
        {
            return this.salary.CompareTo(other.salary);
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
