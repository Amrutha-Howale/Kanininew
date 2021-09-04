using System;
using System.Collections.Generic;
using System.Text;

namespace UnderstandingAbstract
{
    public abstract class Dog
    {
        public void Eat()
        {
            Console.WriteLine("Birds eat......");
        }
        public void Sleep()
        {
            Console.WriteLine("zzzzzzzzzzzzzzzzzzzzzzzzzz");
        }
        public abstract void Look();
    }
}
