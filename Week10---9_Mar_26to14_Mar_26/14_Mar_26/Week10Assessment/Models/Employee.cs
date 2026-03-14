using System.ComponentModel.DataAnnotations;

namespace Week10Assessment.Models;

public class Employee
{
    [Key]
    public int EmployeeId { get; set; }

    [Required]
    [StringLength(100)]
    public string FullName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    // Foreign Key to Department (Many Employees → One Department)
    public int DepartmentId { get; set; }
    public Department? Department { get; set; }

    // Many-to-Many with Project (via join entity)
    public ICollection<EmployeeProject> EmployeeProjects { get; set; } = new List<EmployeeProject>();
}