using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApplication
{
    class Mobile
    {
        public int Speed { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public void Call()
        {
            string phone;
            Console.WriteLine("please enter the phone num to make call");
            phone = Console.ReadLine();
            Console.WriteLine("calling to " + phone);
        }
        public void Printabout()
        {
            Console.WriteLine("name of the mobile is " + Name);
            Console.WriteLine("Price of the mobile is " + Price);
        }
    }
}
