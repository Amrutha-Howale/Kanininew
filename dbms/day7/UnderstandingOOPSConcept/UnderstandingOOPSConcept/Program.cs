using System;

namespace UnderstandingOOPSConcept
{
    class Program
    {
        static void Main(string[] args)
        {
            //Cycle cycle = new MotorCycle();
            //Console.WriteLine("speed is " + cycle.Speed);
            ////Console.WriteLine(cycle.GetType().ToString());
            ////if(cycle.GetType().ToString
            //cycle.Run();
            //cycle = new MountainCycle();
            //Console.WriteLine("speed is " + cycle.Speed);
            //cycle.Run();
            //Console.WriteLine("speed is"+cycle.Speed);
            /* Account account = new Account("jack");
             Console.WriteLine("the name of account holder is "+account.Name);
             account.CreateAccount(243.2f, "Saving");*/
            /*Account account1 = new Account();
            account1.CreateAccount(245.3f);
            Account account2 = new Account();
            account2.CreateAccount(254.4f);
            Account account3 = account1 + account2;
            Console.WriteLine("after adding the account"+account3.Balance);*/
            Dog dog = new Dog();
            dog = new pug();
            dog.Look();
            dog = new GreatDane();
            dog.Look();
            Console.ReadKey();


        }
    }
}
