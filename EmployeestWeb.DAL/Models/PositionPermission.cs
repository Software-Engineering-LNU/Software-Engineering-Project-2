using System;
using System.Collections.Generic;

namespace EmployeestWeb.DAL.Models
{
    public partial class PositionPermission
    {
        public long Id { get; set; }
        public long PositionId { get; set; }
        public long PermissionId { get; set; }

        public virtual Permission Permission { get; set; } = null!;
        public virtual Position Position { get; set; } = null!;
    }
}
