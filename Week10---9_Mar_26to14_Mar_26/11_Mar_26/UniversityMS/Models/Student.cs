using System.ComponentModel.DataAnnotations;

namespace UniversityMS.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Date)]
        public DateTime EnrollmentDate { get; set; }

        public ICollection<Enrollment>? Enrollments { get; set; }
    }
}