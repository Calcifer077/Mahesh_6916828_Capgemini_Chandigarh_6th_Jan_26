using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UniversityMS.Models;

namespace UniversityMS.Data
{
    public class UniversityMSContext : DbContext
    {
        public UniversityMSContext (DbContextOptions<UniversityMSContext> options)
            : base(options)
        {
        }

        public DbSet<UniversityMS.Models.Course> Course { get; set; } = default!;
        public DbSet<UniversityMS.Models.Department> Department { get; set; } = default!;
        public DbSet<UniversityMS.Models.Enrollment> Enrollment { get; set; } = default!;
        public DbSet<UniversityMS.Models.Instructor> Instructor { get; set; } = default!;
        public DbSet<UniversityMS.Models.Student> Student { get; set; } = default!;
    }
}
