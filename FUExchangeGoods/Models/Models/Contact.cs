using System;
using System.Collections.Generic;

namespace Models.Models
{
    public partial class Contact
    {
        public int Id { get; set; }
        public int? UserSend { get; set; }
        public int? UserReceive { get; set; }
        public string? Message { get; set; }

        public virtual User? UserSendNavigation { get; set; }
    }
}
