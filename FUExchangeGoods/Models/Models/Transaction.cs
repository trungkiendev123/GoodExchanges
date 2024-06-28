using System;
using System.Collections.Generic;

namespace Models.Models
{
    public partial class Transaction
    {
        public Transaction()
        {
            Orders = new HashSet<Order>();
        }

        public int TransactionId { get; set; }
        public int? BuyerId { get; set; }
        public int? SellerId { get; set; }
        public int? ProductId { get; set; }
        public int? Status { get; set; }

        public virtual Buyer? Buyer { get; set; }
        public virtual Product? Product { get; set; }
        public virtual Seller? Seller { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
