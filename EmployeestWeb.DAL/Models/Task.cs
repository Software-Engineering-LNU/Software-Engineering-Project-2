namespace EmployeestWeb.DAL.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Task
    {
        public long Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Status { get; set; } = null!;

        public int StoryPoints { get; set; }

        public long TeamId { get; set; }

        public long UserId { get; set; }

        public virtual Team Team { get; set; } = null!;

        public virtual User? User { get; set; }
    }
}
