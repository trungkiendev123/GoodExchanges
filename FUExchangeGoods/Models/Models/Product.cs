using System;
using System.Collections.Generic;

namespace Models.Models
{
    public partial class Product
    {
        public Product()
        {
            CartItems = new HashSet<CartItem>();
            Transactions = new HashSet<Transaction>();
        }

        public int ProductId { get; set; }
        public int? SellerId { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
        public int? Quantity { get; set; }
        public int? CategoryId { get; set; }
        public DateTime? DatePosted { get; set; }
        public int? Status { get; set; }
        public string? Image { get; set; }

        public virtual Category? Category { get; set; }
        public virtual Seller? Seller { get; set; }
        public virtual Order? Order { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
