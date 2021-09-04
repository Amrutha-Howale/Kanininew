using System;
using System.Collections.Generic;
using System.Text;

namespace UnderstandingAbstract
{
    public class Bird : IFlying,IAnimal
    {
        public string Name { get; set; }
        public Bird()
        {
            Console.WriteLine("You have created a bird");
        }
        public Bird(String name)
        {
            Name = name;
        }
        public void Eat()
        {
            Console.WriteLine("Birds eat......");
        }
        public void Sleep()
        {
            Console.WriteLine("zzzzzzzzzzzzzzzzzzzzzzzzzz");
        }
        public void Fly()
        {
            Console.WriteLine("FLY FLY FLY");
        }

        public void Land()
        {
            Console.WriteLine("Stop flapping wings.");
        }

        public void Takeoff()
        {
            Console.WriteLine("Flap wings fast");
        }
    }
}
