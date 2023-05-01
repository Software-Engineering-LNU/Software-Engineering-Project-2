namespace EmployeestWeb.Models
{
    using System.ComponentModel.DataAnnotations;

    public class AddEmployeeTeamViewModel
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; } = string.Empty;

        public int TeamId { get; set; }
    }
}
