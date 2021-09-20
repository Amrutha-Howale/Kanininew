using System;
using System.Collections.Generic;

#nullable disable

namespace PizzaDeliveryApplication.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
            ToppingDetails = new HashSet<ToppingDetail>();
        }

        public int OrderId { get; set; }
        public double TotalPrice { get; set; }
        public int? CustId { get; set; }
        public string DeliveryAddress { get; set; }
        public DateTime OrderDate { get; set; }

        public virtual Customer Cust { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<ToppingDetail> ToppingDetails { get; set; }
    }
}
