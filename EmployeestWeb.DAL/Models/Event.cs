using System;
using System.Collections.Generic;

namespace EmployeestWeb.DAL.Models
{
    public partial class Event
    {
        public Event()
        {
            EventMembers = new HashSet<EventMember>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public DateOnly Date { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }

        public virtual ICollection<EventMember> EventMembers { get; set; }
    }
}
