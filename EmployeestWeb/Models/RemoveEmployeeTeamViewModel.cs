namespace EmployeestWeb.Models
{
    public class RemoveEmployeeTeamViewModel
    {
        public string Email { get; set; } = string.Empty;

        public int TeamId { get; set; }

        public int UserId { get; set; }
    }
}
