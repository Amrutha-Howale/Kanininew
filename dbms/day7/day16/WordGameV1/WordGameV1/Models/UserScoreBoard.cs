using System;
using System.Collections.Generic;

#nullable disable

namespace WordGameV1.Models
{
    public partial class UserScoreBoard
    {
        public int UserId { get; set; }
        public int? Score { get; set; }

        public virtual User User { get; set; }
    }
}
