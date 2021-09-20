using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShopApplication
{
    public class ItemsList
    {
        [Key]
        public int ItemId { get; set; }
        public int ProductNumber { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public int Quantity { get; set; }
        public ICollection<ItemsList> itemsLists { get; set; }
    }
}
