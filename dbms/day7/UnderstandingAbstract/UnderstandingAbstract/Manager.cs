using System;
using System.Collections.Generic;
using System.Text;

namespace UnderstandingAbstract
{
    public class Manager : ICustomerManager,IEmployeeManager
    {
        public Manager()
        {
            Console.WriteLine("You have created a Manager");
        }
        void ICustomerManager.ApproveLoan()
        {
            Console.WriteLine("Manager approves loan");
        }

        void ICustomerManager.SolveIssues()
        {
            Console.WriteLine("Manager solves Customer issue");
        }

        void IEmployeeManager.ConductMeeting()
        {
            Console.WriteLine("Manager conducts meeting");
        }

        void IEmployeeManager.CheckWork()
        {
            Console.WriteLine("Manager checks work");
        }
    }
}
