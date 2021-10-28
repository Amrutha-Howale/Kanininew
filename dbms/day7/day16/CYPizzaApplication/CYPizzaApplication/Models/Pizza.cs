using System;
using System.Collections.Generic;

#nullable disable

namespace CYPizzaApplication.Models
{
    public partial class Pizza
    {
        public Pizza()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int PizzaId { get; set; }
        public string Name { get; set; }
        public double? Price { get; set; }
        public string Speciality { get; set; }
        public string IsVeg { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
