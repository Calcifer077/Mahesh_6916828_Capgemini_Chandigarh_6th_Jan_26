using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CompanyHRMS.Models
{
    public class Company
    {
        public int CompanyId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Location { get; set; }

        // Navigation Property
        public List<Employee>? Employees { get; set; }
    }
}