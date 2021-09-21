using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondNVCApplication.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Employee> employees { get; set; }
    }
}
