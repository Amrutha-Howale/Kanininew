using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApplication
{
    class Car
    {
        public int MaxSpeed { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public void Details()
        {
            Console.WriteLine("The name of the car is " + Name);
            Console.WriteLine("The Speed of the car is " + MaxSpeed);
            Console.WriteLine("The price of the car is " + Price);

        }
    }
}
