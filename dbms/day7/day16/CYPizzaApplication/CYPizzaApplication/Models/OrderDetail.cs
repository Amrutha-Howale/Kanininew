using System;
using System.Collections.Generic;

#nullable disable

namespace CYPizzaApplication.Models
{
    public partial class OrderDetail
    {
        public OrderDetail()
        {
            ToppinngDetails = new HashSet<ToppinngDetail>();
        }

        public int ItemId { get; set; }
        public int? OrderId { get; set; }
        public int? PizzaId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Pizza Pizza { get; set; }
        public virtual ICollection<ToppinngDetail> ToppinngDetails { get; set; }
    }
}
