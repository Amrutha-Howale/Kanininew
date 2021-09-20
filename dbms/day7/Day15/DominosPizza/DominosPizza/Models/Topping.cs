using System;
using System.Collections.Generic;

#nullable disable

namespace DominosPizza.Models
{
    public partial class Topping
    {
        public Topping()
        {
            ToppingDetails = new HashSet<ToppingDetail>();
        }

        public int Id { get; set; }
        public string ToppingsName { get; set; }
        public int Price { get; set; }

        public virtual ICollection<ToppingDetail> ToppingDetails { get; set; }
    }
}
