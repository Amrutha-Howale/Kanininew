using System;
using System.Collections.Generic;

#nullable disable

namespace CodeFirstApproach.Models
{
    public partial class TblSalary
    {
        public string Id { get; set; }
        public double? Basic { get; set; }
        public double? Hra { get; set; }
        public double? Da { get; set; }
        public double? Deductions { get; set; }
    }
}
