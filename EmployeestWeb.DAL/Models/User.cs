using System;
using System.Collections.Generic;

namespace EmployeestWeb.DAL.Models
{
    public partial class User
    {
        public User()
        {
            EventMembers = new HashSet<EventMember>();
            ProjectMembers = new HashSet<ProjectMember>();
            Projects = new HashSet<Project>();
            Tasks = new HashSet<Task>();
            TeamMembers = new HashSet<TeamMember>();
        }

        public long Id { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public bool IsBusinessOwner { get; set; }

        public virtual ICollection<EventMember> EventMembers { get; set; }
        public virtual ICollection<ProjectMember> ProjectMembers { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
        public virtual ICollection<TeamMember> TeamMembers { get; set; }
    }
}
