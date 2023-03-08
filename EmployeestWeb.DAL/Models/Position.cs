using System;
using System.Collections.Generic;

namespace EmployeestWeb.DAL.Models
{
    public partial class Position
    {
        public Position()
        {
            PositionPermissions = new HashSet<PositionPermission>();
            ProjectMembers = new HashSet<ProjectMember>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<PositionPermission> PositionPermissions { get; set; }
        public virtual ICollection<ProjectMember> ProjectMembers { get; set; }
    }
}
