namespace Week10Assessment.Models.ViewModels
{
    public class ProjectDashboardViewModel
    {
        public int ProjectId { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }

        public List<EmployeeInfo> AssignedEmployees { get; set; } = new List<EmployeeInfo>();
    }

    public class EmployeeInfo
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string DepartmentName { get; set; } = string.Empty;
        public DateTime AssignedDate { get; set; }
    }
}