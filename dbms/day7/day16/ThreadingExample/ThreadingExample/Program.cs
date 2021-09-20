using System;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingExample
{
    class Program
    {
        void Sample1()
        {
            lock (this) 
            {
                for (int i = 0; i < 10;i++)
                {
                    Console.WriteLine(i + " from" + Thread.CurrentThread.Name);
                    Thread.Sleep(1000);
                }
            }
        }
        void Sample2()
        {
            for (int i = 10; i < 100; i=i+10)
            {
                Console.WriteLine(i + "from" + Thread.CurrentThread.Name);
            }
        }
        void UnderstandingTask()
        {
            //Task task = new Task(() =>
            //  {
            //      for (int i = 10; i < 100; i = i + 10)
            //      {
            //          Console.WriteLine(i + "from" + Thread.CurrentThread.Name);
            //          Thread.Sleep(1000);
            //      }
            //  });
            //task.Start();
            Task<int> task = Task.Run(() => 10);
            Console.WriteLine("the result from task is "+task.Result);
        }
        Task<string> GetTheTaskDone()
        {
            return Task.Run(() =>
            {
                Thread.Sleep(3000);
                return "Hello from Task";
            });
        }
        async void PrintTaskValue()
        {
            string value = await GetTheTaskDone();
            Console.WriteLine(value);
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.PrintTaskValue();
            //program.UnderstandingTask();
            /*Thread t1 = new Thread(program.Sample1);
            t1.Name = "Thread1";
            Thread t2 = new Thread(program.Sample1);
            t2.Name = "Thread2";
            t1.Start();
            t2.Start();*/
            Console.ReadKey();
        }
    }
}
