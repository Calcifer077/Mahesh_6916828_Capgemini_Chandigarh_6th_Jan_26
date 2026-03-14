using System.ComponentModel.DataAnnotations;
using Week10Assessment.Models;

namespace Week10Assessment.Models
{

    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        // Navigation property: One Department → Many Employees
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}