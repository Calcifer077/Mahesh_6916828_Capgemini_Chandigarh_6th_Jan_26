using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EcommerceSystem.Models;

namespace EcommerceSystem.Data
{
    public class EcommerceSystemContext : DbContext
    {
        public EcommerceSystemContext (DbContextOptions<EcommerceSystemContext> options)
            : base(options)
        {
        }

        public DbSet<EcommerceSystem.Models.Customer> Customer { get; set; } = default!;
        public DbSet<EcommerceSystem.Models.Product> Product { get; set; } = default!;
        public DbSet<EcommerceSystem.Models.Order> Order { get; set; } = default!;
    }
}
