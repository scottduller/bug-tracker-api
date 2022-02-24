namespace BugTrackerApi.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Tickets Comments
        public ICollection<Comment> Comments { get; set; }

        // Ticket Owner
        public User Owner { get; set; }

        // Parent Project
        public Project Project { get; set; }

        // Ticket Status
        public Status Status { get; set; }
    }
}
