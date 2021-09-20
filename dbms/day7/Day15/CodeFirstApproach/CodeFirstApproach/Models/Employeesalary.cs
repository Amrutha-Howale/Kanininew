using System;
using System.Collections.Generic;

#nullable disable

namespace CodeFirstApproach.Models
{
    public partial class Employeesalary
    {
        public int EmpId { get; set; }
        public int? SalId { get; set; }
        public DateTime? Date { get; set; }
        public int? Extra { get; set; }
        public DateTime? Saldate { get; set; }

        public virtual Salary Sal { get; set; }
    }
}
