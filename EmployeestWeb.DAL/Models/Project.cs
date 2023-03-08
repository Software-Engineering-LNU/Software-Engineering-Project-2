using System;
using System.Collections.Generic;

namespace EmployeestWeb.DAL.Models
{
    public partial class Project
    {
        public Project()
        {
            ProjectMembers = new HashSet<ProjectMember>();
            Teams = new HashSet<Team>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public long OwnerId { get; set; }

        public virtual User Owner { get; set; } = null!;
        public virtual ICollection<ProjectMember> ProjectMembers { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
    }
}
