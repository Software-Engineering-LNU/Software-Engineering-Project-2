namespace EmployeestWeb.Models
{
    public class AddTaskViewModel
    {
        public AddTaskViewModel()
        {
            this.Name = string.Empty;
            this.Description = string.Empty;
        }

        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Status { get; set; } = null!;

        public int StoryPoints { get; set; }

        public long TeamId { get; set; }

        public long UserId { get; set; }
    }
}
