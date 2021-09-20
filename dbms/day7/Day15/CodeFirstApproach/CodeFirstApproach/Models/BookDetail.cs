using System;
using System.Collections.Generic;

#nullable disable

namespace CodeFirstApproach.Models
{
    public partial class BookDetail
    {
        public string Bookname { get; set; }
        public string Bookprice { get; set; }
        public string Author { get; set; }
        public int? Quantity { get; set; }
        public string Totalprice { get; set; }
    }
}
