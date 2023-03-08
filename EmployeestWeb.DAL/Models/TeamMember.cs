using System;
using System.Collections.Generic;

namespace EmployeestWeb.DAL.Models
{
    public partial class TeamMember
    {
        public long Id { get; set; }
        public long TeamId { get; set; }
        public long UserId { get; set; }

        public virtual Team Team { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
