using System;
using System.Collections.Generic;

namespace Models.Models
{
    public partial class Seller
    {
        public Seller()
        {
            Orders = new HashSet<Order>();
            Products = new HashSet<Product>();
            Reports = new HashSet<Report>();
            Transactions = new HashSet<Transaction>();
        }

        public int SellerId { get; set; }
        public int? UserId { get; set; }

        public virtual User? User { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
