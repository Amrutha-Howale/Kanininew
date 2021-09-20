using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace CollectionEmployeeAssignment
{
    public class EmployeeDetailsCollection
    {
            Dictionary<int, Employee> employee;
            List<Employee> sortedbysalary;
            public EmployeeDetailsCollection()
            {
                employee = new Dictionary<int, Employee>();
                //addemployee = new List<Employee>();
                sortedbysalary = new List<Employee>();
            }

        /// <summary>
        /// Taking choices from the user for different conditions
        /// </summary>
        public void EmployeeInformation()
        {
            string UserChoices;
            do
            {
                Console.WriteLine("Please Enter The following Character To  Add and Display The Employee Details");
                Console.WriteLine("key in 'a' for AddEmployee and 'p' for print employee details and 'S' for sorting");
                Console.WriteLine("Key in 'i' to print employee details by id");
                Console.WriteLine("Key in 'n' to print employee details by name");
                Console.WriteLine("Key in 'el' to print employee details by elder");
                Console.WriteLine("enter 1 to modify name");
                Console.WriteLine("enter 2 to modify age");
                Console.WriteLine("enter 3 to modify salary");
                Console.WriteLine("enter 4 to remove employee");
                Console.WriteLine("Key in e to exit");
                UserChoices = Console.ReadLine().ToLower();
                switch (UserChoices)
                {
                    case "a":
                        EmployeeDetailStoring();
                        break;
                    case "p":
                        PrintEmployee();
                        break;
                    case "s":
                        EmployeeSorting();
                        break;
                    case "i":
                        PrintEmployeeDetailsById();
                        break;
                    case "n":
                        PrintEmployeeDetailsByName();
                        break;
                    case "el":
                        ElderThanCurrentEmploye();
                        break;
                    case "1":
                        ModifyEmployeeDetails("name");
                        break;
                    case "2":
                        ModifyEmployeeDetails("age");
                        break;
                    case "3":
                        ModifyEmployeeDetails("salary");
                        break;
                    case "4":
                        ModifyEmployeeDetails("remove");
                        break;
                    case "e":
                        Console.WriteLine("we are done creating accounts");
                        break;
                    default:
                        Console.WriteLine("Ïnvalid option, please try again");
                        break;
                }

            } while (UserChoices != "e");
        }
        public void EmployeeDetailStoring()
        {
            bool flag = true;
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
                    //addemployee.RemoveAt(addemployee.Count - 1);
                    Console.WriteLine(e.Message);
                    flag = true;

                }
            } while (flag);
            sortedbysalary = employee.Values.ToList();
            //sortedbysalary.Sort();

        }
        public void PrintEmployee()
        {
           
            /*for (int i = 0; i < employee.Count; i++)
            {
                if (EmpId ==)
                {
                    int index1 = EmployeeNames.IndexOf(EmployeeNames[i]);
                    Console.WriteLine($"{EmployeeNames[i]} is in the position {index1 + 1} for promotion");
                }*/
                foreach (var item in employee)
            {
                Console.WriteLine(item);
            }


        }
        public void EmployeeCompair()
        {
            Console.WriteLine("Enter the id :");
            int EmpId =Convert.ToInt32( Console.ReadLine());
            foreach (var item in employee)
            {
                if (item.Key == EmpId)
                {
                    Console.WriteLine(item);
                }
            }
        }
        public void EmployeeSorting()
        {
            //addemployee.foreach (Employee => Console.WriteLine(Employee.sal)) ;
            sortedbysalary.Sort();
            foreach (var item in sortedbysalary)
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

        /* public int CompareTo(Employee other)
          {
              return this.salary.CompareTo(other.salary);
          }*/
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
                var employeeDetailsById = from obj in sortedbysalary
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
        public void PrintEmployeeDetailsByName()
        {

            if (ToCheckListIsEmpty())
            {
                Console.WriteLine("Enter employee name");
                string employeeName = Console.ReadLine();
                var employeeDetailsByName = from obj in sortedbysalary
                                            where obj.Name == employeeName
                                            select obj;
                if (employeeDetailsByName.Count() == 0)
                    Console.WriteLine($"No employe with name {employeeName}");
                else
                {
                    foreach (var item in employeeDetailsByName)
                        PrintEmployeeDetails(item);
                }

            }
        }
        public void ElderThanCurrentEmploye()
        {
            if (ToCheckListIsEmpty())
            {
                int count = 0, employeeAge = 0;
                Console.WriteLine("Enter employee name");
                string employeeName = Console.ReadLine();
                foreach (var item in sortedbysalary)
                {
                    if (item.Name == employeeName)
                    {
                        employeeAge = item.Age;
                        count++;
                        break;
                    }

                }
                if (count == 0)
                    Console.WriteLine($"No employee with name {employeeName}");
                else
                {
                    var employeeDetails = from obj in sortedbysalary
                                          where obj.Age > employeeAge
                                          select obj;
                    foreach (var item in employeeDetails)
                        PrintEmployeeDetails(item);

                }

            }
        }

        /// <summary>
        /// Checks if the list is empty or not, and taking the employee id from user
        /// </summary>
        Employee EmployeDetailsOfId()
        {
            if (!ToCheckListIsEmpty())
            {
                return null;
            }
            else
            {
                Console.WriteLine("Enter employee ID");
                int id = UserIntInput();
                foreach (var item in sortedbysalary)
                {
                    if (item.Id == id)
                        return item;

                }

            }

            return null;
        }

        /// <summary>
        /// Used to modify the name of the employee of id which is entered by the user
        /// </summary>
        /// <param name="modifyEmployee"></param>
        void ModifyEmployeName(Employee modifyEmployee)
        {
            Console.WriteLine("Enter Employee new name");
            string newEmployeName = Console.ReadLine();
            modifyEmployee.Name = newEmployeName;
            Console.WriteLine("employee name is modified");
        }

        /// <summary>
        /// Used to modify the age of the employee of id which is entered by the user
        /// </summary>
        /// <param name="modifyEmployee"></param>
        void ModifyEmployeAge(Employee modifyEmployee)
        {
            Console.WriteLine("Enter user new age");
            int newEmployeeAge = UserIntInput();
            modifyEmployee.Age = newEmployeeAge;
            Console.WriteLine("employee age is modified");
        }
        void ModifyEmployeeSalary(Employee modifyEmployee)
        {
            Console.WriteLine("enter new salary");
            double newEmployeeSalary = Convert.ToDouble(Console.ReadLine());
            modifyEmployee.Salary = newEmployeeSalary;
            sortedbysalary.Sort();
            Console.WriteLine("employee salary is modified");

        }
        void RemoveEmployee(Employee modifyEmployee)
        {
            sortedbysalary.Remove(modifyEmployee);
            employee.Remove(modifyEmployee.Id);
            Console.WriteLine("EMPLOYEE REMOVED...");
        }

        /// <summary>
        /// choice of the user is taken from the EmployeeInformation function and implemented in this ModifyEmployeeDetails function
        /// </summary>
        /// <param name="userChoice"></param>
        public void ModifyEmployeeDetails(string userChoice)
        {
            Employee modifyEmployee = EmployeDetailsOfId();
            if (modifyEmployee == null)
            {
                Console.WriteLine(" or No employee with given id");
            }
            else
            {

                switch (userChoice)
                {
                    case "name":

                        ModifyEmployeName(modifyEmployee);

                        break;
                    case "age":

                        ModifyEmployeAge(modifyEmployee);

                        break;
                    case "salary":

                        ModifyEmployeeSalary(modifyEmployee);

                        break;
                    case "remove":
                        RemoveEmployee(modifyEmployee);
                        break;
                    default:
                        break;
                }
            }

        }

    }
    }

