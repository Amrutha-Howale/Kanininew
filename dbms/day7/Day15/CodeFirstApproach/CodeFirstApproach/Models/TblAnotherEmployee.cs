using System;
using System.Collections.Generic;

#nullable disable

namespace CodeFirstApproach.Models
{
    public partial class TblAnotherEmployee
    {
        public int AnotherEmpId { get; set; }
        public int? EmpId { get; set; }
        public string EmpName { get; set; }

        public virtual TblEmpl Emp { get; set; }
    }
}
