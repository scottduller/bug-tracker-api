namespace BugTrackerApi.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Projects Users
        public ICollection<User> Users { get; set; }

        // Projects Statuses
        public ICollection<Status> Statuses { get; set; }

        // Projects Tickets
        public ICollection<Ticket> Tickets { get; set; }

        // Project Owner
        public User Owner { get; set; }

        // Parent Organisation
        public Organisation Organisation { get; set; }

    }
}
