using System;
using System.Collections.Generic;

#nullable disable

namespace PizzaDeliveryApplication.Models
{
    public partial class ToppingDetail
    {
        public int OrderId { get; set; }
        public int DetailsId { get; set; }
        public int ToppingsId { get; set; }

        public virtual OrderDetail Details { get; set; }
        public virtual Order Order { get; set; }
        public virtual Topping Toppings { get; set; }
    }
}
