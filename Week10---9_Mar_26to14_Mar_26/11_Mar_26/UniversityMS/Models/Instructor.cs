using System.ComponentModel.DataAnnotations;

namespace UniversityMS.Models
{
    public class Instructor
    {
        public int InstructorId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int DepartmentId { get; set; }

        public Department? Department { get; set; }
        public ICollection<Course>? Courses { get; set; }
    }
}