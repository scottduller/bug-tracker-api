using Microsoft.EntityFrameworkCore;

namespace BugTrackerApi.Models
{
    public class BugTrackerApiContext : DbContext

    {
        public string DbPath { get; }
        public BugTrackerApiContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "bugTracker.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Organisations Users (M-M)
            modelBuilder
                .Entity<User>()
                .HasMany(u => u.Organisations)
                .WithMany(o => o.Users)
                .UsingEntity(uo => uo.ToTable("UsersOrganisations"));

            // Projects Users (M-M)
            modelBuilder
                .Entity<User>()
                .HasMany(u => u.Projects)
                .WithMany(o => o.Users)
                .UsingEntity(uo => uo.ToTable("UsersProjects"));

            // User owns Organisations (1-M)
            modelBuilder
                .Entity<User>()
                .HasMany(u => u.OrganisationsOwned)
                .WithOne(o => o.Owner);

            // User owns Projects (1-M)
            modelBuilder
                .Entity<User>()
                .HasMany(u => u.ProjectsOwned)
                .WithOne(p => p.Owner);

            // User owns Tickets (1-M)
            modelBuilder
                .Entity<User>()
                .HasMany(u => u.TicketsOwned)
                .WithOne(t => t.Owner);

            // User owns Comments (1-M)
            modelBuilder
                .Entity<User>()
                .HasMany(u => u.CommentsOwned)
                .WithOne(c => c.Owner);

            // Organisation owns Projects (1-M)
            modelBuilder
                .Entity<Organisation>()
                .HasMany(o => o.Projects)
                .WithOne(p => p.Organisation);

            // Organisation owns Statuses (1-M)
            modelBuilder
                .Entity<Organisation>()
                .HasMany(o => o.Statuses)
                .WithOne(s => s.Organisation);

            // Project owns Statuses (1-M)
            modelBuilder
                .Entity<Project>()
                .HasMany(p => p.Statuses)
                .WithOne(s => s.Project);

            // Project owns Tickets (1-M)
            modelBuilder
                .Entity<Project>()
                .HasMany(p => p.Tickets)
                .WithOne(t => t.Project);

            // Ticket owns Comments (1-M)
            modelBuilder
                .Entity<Ticket>()
                .HasMany(t => t.Comments)
                .WithOne(c => c.Ticket);

            // Status assigned to Tickets (1-M)
            modelBuilder
                .Entity<Status>()
                .HasMany(s => s.Tickets)
                .WithOne(t => t.Status);

            // Comment children comments (1-M)
            modelBuilder
                .Entity<Comment>()
                .HasMany(c => c.Children)
                .WithOne(c => c.Parent);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Organisation> Organisations { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
