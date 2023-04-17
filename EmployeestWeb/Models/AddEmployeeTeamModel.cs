namespace EmployeestWeb.Models
{
    using System.ComponentModel.DataAnnotations;

    public class AddEmployeeTeamModel
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; } = string.Empty;
    }
}
