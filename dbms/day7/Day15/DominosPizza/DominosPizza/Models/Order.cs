using System;
using System.Collections.Generic;

#nullable disable

namespace DominosPizza.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int OrderId { get; set; }
        public double TotalPrice { get; set; }
        public int? CustId { get; set; }
        public string DeliveryAddress { get; set; }
        public DateTime OrderDate { get; set; }

        public virtual Customer Cust { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
