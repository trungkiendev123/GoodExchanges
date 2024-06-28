using System;
using System.Collections.Generic;

namespace Models.Models
{
    public partial class Account
    {
        public Account()
        {
            Users = new HashSet<User>();
        }

        public int AccountId { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public int? Status { get; set; }
        public int? Role { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
