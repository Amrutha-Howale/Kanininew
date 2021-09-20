using System;
using System.Collections.Generic;

#nullable disable

namespace PizzaDeliveryApplication.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int CustId { get; set; }
        public string CustName { get; set; }
        public string CustEmail { get; set; }
        public string CustPassword { get; set; }
        public string CustAddress { get; set; }
        public string CustPhone { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
