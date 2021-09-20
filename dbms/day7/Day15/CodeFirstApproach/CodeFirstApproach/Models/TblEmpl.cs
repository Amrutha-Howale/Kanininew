using System;
using System.Collections.Generic;

#nullable disable

namespace CodeFirstApproach.Models
{
    public partial class TblEmpl
    {
        public TblEmpl()
        {
            TblAnotherEmployees = new HashSet<TblAnotherEmployee>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TblAnotherEmployee> TblAnotherEmployees { get; set; }
    }
}
