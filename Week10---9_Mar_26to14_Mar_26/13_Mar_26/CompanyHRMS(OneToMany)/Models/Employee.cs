using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyHRMS.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Position { get; set; }

        // Foreign Key
        public int CompanyId { get; set; }

        // Navigation Property
        public Company? Company { get; set; }
    }
}