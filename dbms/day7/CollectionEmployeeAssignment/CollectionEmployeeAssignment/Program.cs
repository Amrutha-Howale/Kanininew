using System;

namespace CollectionEmployeeAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            EmployeePromotion employeePromotion = new EmployeePromotion();
            employeePromotion.EmployeePromotionList();
            //employeePromotion.PrintEmployee();
            //employeePromotion.PrintPostion();
            employeePromotion.RemoveExcessMemory();
            Console.ReadKey();
        }
    }
}
