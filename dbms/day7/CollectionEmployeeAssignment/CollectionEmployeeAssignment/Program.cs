using System;
using System.Collections.Generic;

namespace CollectionEmployeeAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeDetailsCollection employee = new EmployeeDetailsCollection();
            employee.EmployeeInformation();
            Console.ReadKey();
        }
    }
}
