using BookStore.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace BookStore.Infrastructure.Data;

public class BookStoreDbContextFactory : IDesignTimeDbContextFactory<BookStoreDbContext>
{
    public BookStoreDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<BookStoreDbContext>();

        optionsBuilder.UseSqlServer(
            "Server=(localdb)\\mssqllocaldb;Database=BookStoreSat;Trusted_Connection=True;"
        );

        return new BookStoreDbContext(optionsBuilder.Options);
    }
}

public class BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : DbContext(options)
{
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<User> Users => Set<User>();
    public DbSet<UserProfile> UserProfiles => Set<UserProfile>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Author> Authors => Set<Author>();
    public DbSet<Publisher> Publishers => Set<Publisher>();
    public DbSet<Book> Books => Set<Book>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();
    public DbSet<Review> Reviews => Set<Review>();
    public DbSet<Wishlist> Wishlists => Set<Wishlist>();
    public DbSet<EmailLog> EmailLogs => Set<EmailLog>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // One-to-one: User ↔ UserProfile
        modelBuilder
            .Entity<User>()
            .HasOne(u => u.Profile)
            .WithOne(p => p.User)
            .HasForeignKey<UserProfile>(p => p.UserId);

        // Many-to-many: User ↔ Book (Wishlist — composite PK)
        modelBuilder.Entity<Wishlist>().HasKey(w => new { w.UserId, w.BookId });

        // Book price precision
        modelBuilder.Entity<Book>().Property(b => b.Price).HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Order>().Property(o => o.TotalAmount).HasColumnType("decimal(18,2)");

        // Seed roles
        modelBuilder
            .Entity<Role>()
            .HasData(
                new Role { RoleId = 1, RoleName = "Admin" },
                new Role { RoleId = 2, RoleName = "Customer" }
            );

        modelBuilder.Entity<UserProfile>().HasKey(up => up.ProfileId);
    }
}
