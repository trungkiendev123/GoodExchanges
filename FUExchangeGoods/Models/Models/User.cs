using System;
using System.Collections.Generic;

namespace Models.Models
{
    public partial class User
    {
        public User()
        {
            Buyers = new HashSet<Buyer>();
            Carts = new HashSet<Cart>();
            Contacts = new HashSet<Contact>();
            Sellers = new HashSet<Seller>();
        }

        public int UserId { get; set; }
        public int? AccountId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }

        public virtual Account? Account { get; set; }
        public virtual ICollection<Buyer> Buyers { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
        public virtual ICollection<Seller> Sellers { get; set; }
    }
}
