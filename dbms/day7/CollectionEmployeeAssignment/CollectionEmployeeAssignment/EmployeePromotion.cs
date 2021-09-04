using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionEmployeeAssignment
{
    class EmployeePromotion
    {
        List<String> EmployeeNames = new List<String>();
        public void EmployeePromotionList()
        {
            Console.WriteLine("Enter the Employee names");
            String input= Console.ReadLine();
            if (!string.IsNullOrEmpty(input))
            {
                EmployeePromotionList();
                EmployeeNames.Add(input);
                //PrintEmployee();
            }
        }
        public void PrintEmployee()
        {
            Console.WriteLine("after adding all employee");
            foreach (var user in EmployeeNames)
            {
                Console.WriteLine(user);
            }
        }
        public void PrintPostion()
        {
            Console.WriteLine("Please enter the name of the employee to check promotion position");
            string EmpNames = Console.ReadLine();
            for (int i = 0; i < EmployeeNames.Count; i++)
            {
                if (EmpNames == EmployeeNames[i])
                {
                    //int index1 = EmployeeNames.IndexOf(EmployeeNames[i]);
                    Console.WriteLine($"{EmployeeNames[i]} is in the position {i+1} for promotion");
                }
            }
        }
        public void RemoveExcessMemory()
        {
            Console.WriteLine(" The Current Size of Collection " + EmployeeNames.Capacity);
            EmployeeNames.TrimExcess();
            Console.WriteLine(" The size after removing the extra space is" + EmployeeNames.Capacity);
        }
    }
}
