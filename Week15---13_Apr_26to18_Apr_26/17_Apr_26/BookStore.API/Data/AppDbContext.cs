using BookStore.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Book> Books => Set<Book>();
}