namespace EmployeestWeb.DAL.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Position
    {
        public Position()
        {
            this.PositionPermissions = new HashSet<PositionPermission>();
            this.ProjectMembers = new HashSet<ProjectMember>();
        }

        public long Id { get; set; }

        public string Name { get; set; } = null!;

        public virtual ICollection<PositionPermission> PositionPermissions { get; set; }

        public virtual ICollection<ProjectMember> ProjectMembers { get; set; }
    }
}
