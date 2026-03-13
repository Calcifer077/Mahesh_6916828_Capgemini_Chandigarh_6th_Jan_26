using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CompanyHRMS.Models;

namespace CompanyHRMS.Data
{
    public class CompanyHRMSContext : DbContext
    {
        public CompanyHRMSContext (DbContextOptions<CompanyHRMSContext> options)
            : base(options)
        {
        }

        public DbSet<CompanyHRMS.Models.Company> Company { get; set; } = default!;
        public DbSet<CompanyHRMS.Models.Employee> Employee { get; set; } = default!;
    }
}
