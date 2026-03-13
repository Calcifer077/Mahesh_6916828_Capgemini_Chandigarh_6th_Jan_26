using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PublishingManagementSystem.Models;

namespace AuthorsAndBooksManyToMany.Data
{
    public class AuthorsAndBooksManyToManyContext : DbContext
    {
        public AuthorsAndBooksManyToManyContext (DbContextOptions<AuthorsAndBooksManyToManyContext> options)
            : base(options)
        {
        }

        public DbSet<PublishingManagementSystem.Models.Author> Author { get; set; } = default!;
        public DbSet<PublishingManagementSystem.Models.Book> Book { get; set; } = default!;
        public DbSet<PublishingManagementSystem.Models.AuthorBook> AuthorBook { get; set; } = default!;
    }
}
