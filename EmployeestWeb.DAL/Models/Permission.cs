namespace EmployeestWeb.DAL.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Permission
    {
        public Permission()
        {
            this.PositionPermissions = new HashSet<PositionPermission>();
        }

        public long Id { get; set; }

        public string Name { get; set; } = null!;

        public virtual ICollection<PositionPermission> PositionPermissions { get; set; }
    }
}
