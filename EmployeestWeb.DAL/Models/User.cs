namespace EmployeestWeb.DAL.Models
{
    using System;
    using System.Collections.Generic;

    public partial class User
    {
        public User()
        {
            this.ProjectMembers = new HashSet<ProjectMember>();
            this.Projects = new HashSet<Project>();
            this.Tasks = new HashSet<Task>();
            this.TeamMembers = new HashSet<TeamMember>();
        }

        public long Id { get; set; }

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string FullName { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public bool IsBusinessOwner { get; set; }

        public virtual ICollection<ProjectMember> ProjectMembers { get; set; }

        public virtual ICollection<Project> Projects { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }

        public virtual ICollection<TeamMember> TeamMembers { get; set; }

        public override bool Equals(object? obj)
        {
            var item = obj as User;

            if (item == null)
            {
                return false;
            }

            return this.Id.Equals(item.Id);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
