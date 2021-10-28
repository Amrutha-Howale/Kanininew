using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoginMVC.Models
{
    public class User
    {
        [Required(ErrorMessage = "This field is required")]
        public int Id { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This field is required")]
        public String Password { get; set; }
       
        public string LoginErrorMessage { get; set; }
    }
}
