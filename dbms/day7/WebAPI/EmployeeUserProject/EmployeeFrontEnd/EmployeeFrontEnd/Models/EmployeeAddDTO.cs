using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeFrontEnd.Models
{
    public class EmployeeAddDTO
    {
        [Key]
        public string EmpID { get; set; }

        public string Name { get; set; }

        public string Age { get; set; }
    }
}
