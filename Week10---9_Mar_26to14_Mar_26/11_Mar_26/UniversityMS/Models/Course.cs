using System.ComponentModel.DataAnnotations;

namespace UniversityMS.Models
{
    public class Course
    {
        public int CourseId { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        [Range(1, 6)]
        public int Credits { get; set; }

        [Required]
        public int InstructorId { get; set; }

        public Instructor? Instructor { get; set; }
        public ICollection<Enrollment>? Enrollments { get; set; }
    }
}