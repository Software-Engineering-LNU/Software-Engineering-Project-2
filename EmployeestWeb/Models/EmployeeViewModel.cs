namespace EmployeestWeb.Models
{
    using EmployeestWeb.DAL.Models;

    public class EmployeeViewModel
    {
        public long UserId { get; set; }

        public string FullName { get; set; } = null!;

        public virtual ICollection<Project>? Projects { get; set; }

        public virtual ICollection<Team>? Teams { get; set; }

        public virtual ICollection<Task>? Tasks { get; set; }
    }
}
