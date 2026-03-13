using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FootballerMVC.Models;

namespace FootballerMVC.Data
{
    public class FootballerMVCContext : DbContext
    {
        public FootballerMVCContext (DbContextOptions<FootballerMVCContext> options)
            : base(options)
        {
        }

        public DbSet<FootballerMVC.Models.Club> Club { get; set; } = default!;
        public DbSet<FootballerMVC.Models.Footballer> Footballer { get; set; } = default!;
        public DbSet<FootballerMVC.Models.NationalTeam> NationalTeam { get; set; } = default!;
    }
}
