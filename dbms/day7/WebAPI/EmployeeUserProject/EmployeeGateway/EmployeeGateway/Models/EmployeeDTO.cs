using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeGateway.Models
{
    public class EmployeeDTO
    {
        public string Id { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string jwtToken { get; set; }
    }
}
