using System.ComponentModel.DataAnnotations;

namespace Week10Assessment.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

        public DateTime StartDate { get; set; } = DateTime.UtcNow;

        // Many-to-Many with Employee (via join entity)
        public ICollection<EmployeeProject> EmployeeProjects { get; set; } = new List<EmployeeProject>();
    }
}