using System;
using System.Collections.Generic;

#nullable disable

namespace PizzaDeliveryApplication.Models
{
    public partial class Pizza
    {
        public Pizza()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public string PizzaName { get; set; }
        public double Price { get; set; }
        public string PizzaType { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
