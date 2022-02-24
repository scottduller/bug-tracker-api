namespace BugTrackerApi.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Comment Owner
        public User Owner { get; set; }

        // Parent Ticket
        public Ticket Ticket { get; set; }

        // Children Comments
        public ICollection<Comment> Children { get; set; }

        // Parent Comment
        public Comment? Parent { get; set; }

    }
}