namespace BugTrackerApi.Models
{
    public class Status
    {
        public int StatusId { get; set; }
        public string Name { get; set; }

        // Tickets with status assigned
        public ICollection<Ticket> Tickets { get; set; }

        // Parent Organisation (optional)
        public Organisation? Organisation { get; set; }

        // Parent Project (optional)
        public Project? Project { get; set; }

    }
}
