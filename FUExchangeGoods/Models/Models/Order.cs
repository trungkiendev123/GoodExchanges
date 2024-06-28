using System;
using System.Collections.Generic;

namespace Models.Models
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public int? BuyerId { get; set; }
        public int? SellerId { get; set; }
        public int? TransactionId { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }

        public virtual Buyer? Buyer { get; set; }
        public virtual Product? Product { get; set; }
        public virtual Seller? Seller { get; set; }
        public virtual Transaction? Transaction { get; set; }
    }
}
