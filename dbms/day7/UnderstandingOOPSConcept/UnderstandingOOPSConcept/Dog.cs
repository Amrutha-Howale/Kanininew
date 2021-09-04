using System;
using System.Collections.Generic;
using System.Text;

namespace UnderstandingOOPSConcept
{
    class Dog
    {
        public string behavior { get; set; }
        public virtual void Look()
        {
            Console.WriteLine($"the dog {behavior} ");
        }
    }
    class pug : Dog
    {
        public pug() {
            behavior = "barks";
        }
        public override void Look()
        {
            Console.WriteLine($"the pug dog {behavior} ");
        }
        
        }
    class GreatDane:Dog
    {
        public GreatDane()
        {
            behavior = "bites";
        }
        public override void Look()
        {
            Console.WriteLine($"the GreatDane dog {behavior} ");
        }
    }
         
    }

