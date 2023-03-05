using System;
using System.Collections.Generic;

namespace EmployeestWeb.DAL.Models
{
    public partial class ProjectMember
    {
        public long Id { get; set; }
        public long ProjectId { get; set; }
        public long UserId { get; set; }
        public long PositionId { get; set; }
        public decimal Salary { get; set; }

        public virtual Position Position { get; set; } = null!;
        public virtual Project Project { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
