using System;
using System.Collections.Generic;

#nullable disable

namespace CYPizzaApplication.Models
{
    public partial class Topping
    {
        public Topping()
        {
            ToppinngDetails = new HashSet<ToppinngDetail>();
        }

        public int ToppingId { get; set; }
        public string Name { get; set; }
        public double? Price { get; set; }

        public virtual ICollection<ToppinngDetail> ToppinngDetails { get; set; }
    }
}
