using System.ComponentModel.DataAnnotations;

namespace Week10Assessment.Models
{
    public class EmployeeProject
    {
        public int Id { get; set; }

        // Composite Key will be configured in Fluent API
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }

        [Required]
        public DateTime AssignedDate { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public Employee? Employee { get; set; }
        public Project? Project { get; set; }
    }
}