using System;
using System.Collections.Generic;

namespace EmployeestWeb.DAL.Models
{
    public partial class Permission
    {
        public Permission()
        {
            PositionPermissions = new HashSet<PositionPermission>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<PositionPermission> PositionPermissions { get; set; }
    }
}
