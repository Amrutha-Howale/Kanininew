using System;
using System.Collections.Generic;

#nullable disable

namespace CYPizzaApplication.Models
{
    public partial class ToppinngDetail
    {
        public int ItemId { get; set; }
        public int ToppingId { get; set; }

        public virtual OrderDetail Item { get; set; }
        public virtual Topping Topping { get; set; }
    }
}
