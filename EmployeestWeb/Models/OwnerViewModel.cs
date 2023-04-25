namespace EmployeestWeb.Models
{
    using EmployeestWeb.DAL.Models;

    public class OwnerViewModel
    {
        public long UserId { get; set; }

        public string FullName { get; set; } = null!;

        public virtual ICollection<Project>? Projects { get; set; }
    }
}
