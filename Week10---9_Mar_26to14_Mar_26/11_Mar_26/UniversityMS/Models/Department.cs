using System.ComponentModel.DataAnnotations;

namespace UniversityMS.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public decimal Budget { get; set; }

        public ICollection<Instructor>? Instructors { get; set; }
    }
}