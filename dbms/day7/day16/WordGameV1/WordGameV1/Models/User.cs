using System;
using System.Collections.Generic;

#nullable disable

namespace WordGameV1.Models
{
    public partial class User
    {
        public User()
        {
            UsersWords = new HashSet<UsersWord>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string Phone { get; set; }

        public virtual UserScoreBoard UserScoreBoard { get; set; }
        public virtual ICollection<UsersWord> UsersWords { get; set; }
    }
}
