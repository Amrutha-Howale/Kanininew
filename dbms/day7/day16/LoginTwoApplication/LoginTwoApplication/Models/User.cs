using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoginTwoApplication.Models
{
    public class User
    {
        [Required(ErrorMessage = "This field is required")]
        public string Username { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This field is required")]
        public String Password { get; set; }
        public string Role { get; set; }
        public string Name { get; set; }
    }
    
}
