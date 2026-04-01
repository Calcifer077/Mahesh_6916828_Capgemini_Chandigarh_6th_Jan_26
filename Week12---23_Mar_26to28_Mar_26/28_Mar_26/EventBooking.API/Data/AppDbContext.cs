using EventBooking.API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EventBooking.API.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Event> Events => Set<Event>();
        public DbSet<Booking> Bookings => Set<Booking>();

        protected override void OnModelCreating(ModelBuilder builder)
{
    base.OnModelCreating(builder);

    // Seed Roles only
    builder.Entity<IdentityRole>().HasData(
        new IdentityRole
        {
            Id               = "1",
            Name             = "Admin",
            NormalizedName   = "ADMIN",
            ConcurrencyStamp = "1"
        },
        new IdentityRole
        {
            Id               = "2",
            Name             = "User",
            NormalizedName   = "USER",
            ConcurrencyStamp = "2"
        }
    );

    // Seed Events
    builder.Entity<Event>().HasData(
        new Event
        {
            Id             = 1,
            Title          = "Tech Conference 2025",
            Description    = "Annual technology conference featuring industry leaders.",
            Date           = new DateTime(2025, 10, 15, 9, 0, 0),
            Location       = "Mumbai Convention Center",
            AvailableSeats = 500
        },
        new Event
        {
            Id             = 2,
            Title          = "Startup Pitch Night",
            Description    = "Showcase your startup to top investors.",
            Date           = new DateTime(2025, 9, 20, 18, 0, 0),
            Location       = "Bangalore Tech Park",
            AvailableSeats = 200
        },
        new Event
        {
            Id             = 3,
            Title          = "AI & ML Summit",
            Description    = "Deep dive into Artificial Intelligence and Machine Learning.",
            Date           = new DateTime(2025, 11, 5, 10, 0, 0),
            Location       = "Delhi Innovation Hub",
            AvailableSeats = 350
        }
    );
}
    }
}