using System;

namespace CompanyApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Department department = new Department();
            department.EmployeeDetails();
            department.AddEmployee();
            department.EmployeeReliveDetails();
            department.EmployeeRelive();
        }
    }
}
