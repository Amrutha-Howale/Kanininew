using System;
using System.Collections.Generic;

#nullable disable

namespace CodeFirstApproach.Models
{
    public partial class EmplSal
    {
        public int? EmpId { get; set; }
        public string SalId { get; set; }
        public DateTime? SalDate { get; set; }
        public double? TotalSal { get; set; }

        public virtual TblEmpl Emp { get; set; }
        public virtual TblSalary Sal { get; set; }
    }
}
