using System;
using System.Collections;

namespace UnderstandingArrayList
{
    class Program
    {
        ArrayList myArray;

        public Program()
        {
            myArray = new ArrayList();
        }
        void AddElementsToArray()
        {
            int num = 0;
            Console.WriteLine("please enter numbers. if you want to exit enter -ve number");
            do
            {
                num = Convert.ToInt32(Console.ReadLine());
                myArray.Add(num);
            } while (num>0);
        }
        private void PrintArray()
        {
            //for (int i = 0; i < myArray.Count; i++)
            //{
            //    Console.WriteLine(myArray[i]);
            //}
            foreach (var item in myArray)
            {
                Console.WriteLine(item);
            }
        }
        static void Main(string[] args)
        {
            //Program program = new Program();
            //program.AddElementsToArray();
            //program.PrintArray();
            WorkingWithList working = new WorkingWithList();
            //working.UnderstandingList();
            //working.UnderstandinSets();
            //working.UnderstandingLinkedLIst();
            working.UnderstandingDictionary();
            Console.ReadKey();
        }
    }
}
