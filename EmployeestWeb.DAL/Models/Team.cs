namespace EmployeestWeb.DAL.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Team
    {
        public Team()
        {
            this.Tasks = new HashSet<Task>();
            this.TeamMembers = new HashSet<TeamMember>();
        }

        public long Id { get; set; }

        public string Name { get; set; } = null!;

        public long ProjectId { get; set; }

        public virtual Project Project { get; set; } = null!;

        public virtual ICollection<Task> Tasks { get; set; }

        public virtual ICollection<TeamMember> TeamMembers { get; set; }
    }
}
