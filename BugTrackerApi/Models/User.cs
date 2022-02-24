namespace BugTrackerApi.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool FirstLogin { get; set; }
        public DateTime LastLogin { get; set; }
        public DateTime CreatedAt { get; set; }  
        public DateTime UpdatedAt { get; set; }

        // Organisations involved in
        public ICollection<Organisation> Organisations { get; set; }

        // Project invloved in
        public ICollection<Project> Projects { get; set; }

        // Organisations Owned
        public ICollection<Organisation> OrganisationsOwned { get; set; }

        // Projects Owned
        public ICollection<Project> ProjectsOwned { get; set; }

        // Tickets Owned
        public ICollection<Ticket> TicketsOwned { get; set; }

        // Comments Owned
        public ICollection<Comment> CommentsOwned { get; set; }
    }
}
