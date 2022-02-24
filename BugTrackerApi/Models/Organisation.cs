namespace BugTrackerApi.Models
{
    public class Organisation
    {
        public int OrganisationId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Organisations Users
        public ICollection<User> Users { get; set; }

        // Organisations Projects
        public ICollection<Project> Projects { get; set; }

        // Organisations Statuses
        public ICollection<Status> Statuses { get; set; }

        // Organisation Owner
        public User Owner { get; set; }

    }
}
