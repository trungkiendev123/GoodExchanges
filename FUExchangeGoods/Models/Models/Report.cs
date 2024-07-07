using System;
using System.Collections.Generic;

namespace Models.Models
{
    public partial class Report
    {
        public int ReportId { get; set; }
        public int? BuyerId { get; set; }
        public int? SellerId { get; set; }
        public string? Description { get; set; }
        public DateTime? ReportDate { get; set; }
        public int? Status { get; set; }
        public int? RoleReport { get; set; }

        public virtual Buyer? Buyer { get; set; }
        public virtual Seller? Seller { get; set; }
    }
}
