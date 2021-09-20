using System;
using System.Collections.Generic;

#nullable disable

namespace PizzaDeliveryApplication.Models
{
    public partial class OrderDetail
    {
        public OrderDetail()
        {
            ToppingDetails = new HashSet<ToppingDetail>();
        }

        public int Id { get; set; }
        public int PizzaId { get; set; }
        public int Qty { get; set; }
        public int OrderId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Pizza Pizza { get; set; }
        public virtual ICollection<ToppingDetail> ToppingDetails { get; set; }
    }
}
