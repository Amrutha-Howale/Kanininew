using System;
using System.Collections.Generic;

#nullable disable

namespace ProductListingAndStoringApp.Models
{
    public partial class Product
    {
        public int ProdId { get; set; }
        public string ProdName { get; set; }
        public int? ProdPrice { get; set; }
        public int? Quantity { get; set; }
    }
}
