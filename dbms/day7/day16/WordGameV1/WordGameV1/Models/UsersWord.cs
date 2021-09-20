using System;
using System.Collections.Generic;

#nullable disable

namespace WordGameV1.Models
{
    public partial class UsersWord
    {
        public int UserId { get; set; }
        public string Words { get; set; }

        public virtual User User { get; set; }
    }
}
