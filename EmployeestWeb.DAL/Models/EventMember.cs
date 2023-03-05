using System;
using System.Collections.Generic;

namespace EmployeestWeb.DAL.Models
{
    public partial class EventMember
    {
        public long Id { get; set; }
        public long EventId { get; set; }
        public long UserId { get; set; }

        public virtual Event Event { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
