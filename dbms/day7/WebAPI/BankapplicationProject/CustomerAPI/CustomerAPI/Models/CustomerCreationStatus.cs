using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerAPI.Models
{
    public class CustomerCreationStatus
    {
        [Key]
        public int statusId { get; set; }
        [ForeignKey("Email")]
        //public string Email { get; set; }
        public string Message { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
