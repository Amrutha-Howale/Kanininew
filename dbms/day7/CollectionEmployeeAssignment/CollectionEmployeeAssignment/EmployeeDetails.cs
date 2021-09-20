using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionEmployeeAssignment
{
    public class EmployeeDetails
    {
        Dictionary<int, Employee> employee;
        List<Employee> employeDetailsSortedBySalary;


        public EmployeeDetails()
        {
            employee = new Dictionary<int, Employee>();

            employeDetailsSortedBySalary = new List<Employee>();
        }
        public void AddEmployee()
        {
            bool flag;
            Employee newEmployeeDetails;
            do
            {
                newEmployeeDetails = new Employee();

                try
                {
                    newEmployeeDetails.TakeEmployeeDetailsFromUser();
                    employee.Add(newEmployeeDetails.Id, newEmployeeDetails);
                    flag = false;
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                    flag = true;
                }

            } while (flag);
            employeDetailsSortedBySalary = employee.Values.ToList();
        }
        bool ToCheckListIsEmpty()
        {

            if (employee.Count == 0)
            {
                Console.WriteLine("List is empty");
                return false;
            }
            else
                return true;
        }
        public void SortedListBySalary()
        {


            employeDetailsSortedBySalary.Sort();
            foreach (var item in employeDetailsSortedBySalary)
            {
                PrintEmployeeDetails(item);
            }


        }
        void PrintEmployeeDetails(Employee item)
        {
            Console.WriteLine("--------------------");
            Console.WriteLine(item);
            Console.WriteLine("--------------------");
        }
        /// <summary>
        /// To read inter type value from user.
        /// </summary>
        /// <returns>Integer value</returns>
        int UserIntInput()
        {
            bool flag;
            int id = 0;
            do
            {
                try
                {
                    id = Convert.ToInt32(Console.ReadLine());
                    flag = false;
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                    Console.WriteLine("Enter id");
                    flag = true;
                }

            } while (flag);


            return id;
        }
        /// <summary>
        /// Print Employee detail of particular employee id.
        /// </summary>
        public void PrintEmployeeDetailsById()
        {
            if (ToCheckListIsEmpty())
            {
                Console.WriteLine("Enter employee id:");
                int id = UserIntInput();
                var employeeDetailsById = from obj in employeDetailsSortedBySalary
                                          where obj.Id == id
                                          select obj;
                if (employeeDetailsById.Count() == 0)
                    Console.WriteLine("No employee with given id");
                else
                {
                    foreach (var item in employeeDetailsById)
                        PrintEmployeeDetails(item);

                }

            }

        }
    }
}
