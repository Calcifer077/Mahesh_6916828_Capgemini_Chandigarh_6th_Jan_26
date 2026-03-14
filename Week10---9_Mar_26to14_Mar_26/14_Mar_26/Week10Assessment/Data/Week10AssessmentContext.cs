using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Week10Assessment.Models;

namespace Week10Assessment.Data
{
    public class Week10AssessmentContext : DbContext
    {
        public Week10AssessmentContext (DbContextOptions<Week10AssessmentContext> options)
            : base(options)
        {
        }

        public DbSet<Week10Assessment.Models.Department> Department { get; set; } = default!;
        public DbSet<Week10Assessment.Models.Employee> Employee { get; set; } = default!;
        public DbSet<Week10Assessment.Models.Project> Project { get; set; } = default!;
        public DbSet<Week10Assessment.Models.EmployeeProject> EmployeeProject { get; set; } = default!;
    }
}
