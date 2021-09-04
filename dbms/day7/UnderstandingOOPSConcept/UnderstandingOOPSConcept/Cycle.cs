using System;
using System.Collections.Generic;
using System.Text;

namespace UnderstandingOOPSConcept
{
    public class Cycle
    {
        public int Speed { get; set; }

        public virtual void Run()
        {
            Console.WriteLine($"cycle runs in {Speed} speed");
        }
    }
   
    public class MountainCycle:Cycle
    {
        public MountainCycle()
        {
            Speed = 40;
            Console.WriteLine("can climb mountains");
        }

        public override void Run()
        {
            Console.WriteLine($"MountainCycle runs in {Speed} speed");
        }
    }
    public class MotorCycle : Cycle
    {
        public string Brand { get; set; }
        public MotorCycle()
        {
            Console.WriteLine("can climb mountains");
            Speed = 60;

        }
        public virtual void Run()
        {
            Console.WriteLine($"cycle runs in {Speed} speed");
        }
    }
}
