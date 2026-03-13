using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ECommerceApp.Models;

namespace ECommerceApp.Data
{
    public class ECommerceAppContext : DbContext
    {
        public ECommerceAppContext (DbContextOptions<ECommerceAppContext> options)
            : base(options)
        {
        }

        public DbSet<ECommerceApp.Models.Category> Category { get; set; } = default!;
        public DbSet<ECommerceApp.Models.Customer> Customer { get; set; } = default!;
        public DbSet<ECommerceApp.Models.Order> Order { get; set; } = default!;
        public DbSet<ECommerceApp.Models.OrderDetail> OrderDetail { get; set; } = default!;
        public DbSet<ECommerceApp.Models.Product> Product { get; set; } = default!;
    }
}
