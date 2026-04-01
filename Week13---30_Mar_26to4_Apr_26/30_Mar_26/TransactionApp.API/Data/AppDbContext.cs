using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Transaction> Transactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // ✅ Seed Users
        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Username = "john", Password = "1234" },
            new User { Id = 2, Username = "alice", Password = "1234" }
        );

        // ✅ Seed Transactions
        modelBuilder.Entity<Transaction>().HasData(
            new Transaction { Id = 1, Amount = 1000, Date = new DateTime(2024,1,1), Type = "Credit", UserId = 1 },
            new Transaction { Id = 2, Amount = 500, Date = new DateTime(2024,1,2), Type = "Debit", UserId = 1 },
            new Transaction { Id = 3, Amount = 2000, Date = new DateTime(2024,1,3), Type = "Credit", UserId = 2 }
        );
    }
}