using System;
using System.Collections.Generic;

#nullable disable

namespace DominosPizza.Models
{
    public partial class ToppingDetail
    {
        public int ToppingDetailsId { get; set; }
        public int DetailsId { get; set; }
        public int ToppingsId { get; set; }

        public virtual OrderDetail Details { get; set; }
        public virtual Topping Toppings { get; set; }
    }
}
