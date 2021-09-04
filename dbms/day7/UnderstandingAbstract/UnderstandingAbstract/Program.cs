using System;

namespace UnderstandingAbstract
{
    class Program
    {
        void DogProperties(GreatDane greatDane)
        {
            greatDane.Look();
        }
        void ManagerCustomer(ICustomerManager customerManager)
        {
            customerManager.ApproveLoan();
            customerManager.SolveIssues();
        }
        void EmployeeCustomer(IEmployeeManager employeeManager)
        {
            employeeManager.CheckWork();
            employeeManager.ConductMeeting();
        }
        void VisitForest(IAnimal animal)
        {
            animal.Eat();
            animal.Sleep();
        }
        void SkyShow(IFlying flying)
        {
            flying.Takeoff();
            flying.Fly();
            flying.Land();
        }
        static void Main(string[] args)
        {
            Bird bird = new Bird("parrot");
            Program program = new Program();
            Manager manager = new Manager();
            Dog dog = new GreatDane();
            program.ManagerCustomer(manager);
            program.EmployeeCustomer(manager);
            program.SkyShow(bird);
            program.VisitForest(bird);

            /*int number1 = 3000;
            int number2 = 0;
            Console.WriteLine(number1 / number2);
            Console.ReadKey();*/



            //string str = "757657657657657";
            //int res = int.Parse(str);
        }
    }

}

