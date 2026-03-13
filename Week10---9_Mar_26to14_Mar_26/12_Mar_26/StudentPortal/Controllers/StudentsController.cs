using Microsoft.AspNetCore.Mvc;
using StudentPortal.Models;
using StudentPortal.Services;

namespace StudentPortal.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IRequestLogService _logService;

        public StudentsController(IRequestLogService logService)
        {
            _logService = logService;
        }

        public IActionResult Index()
        {
            var students = new List<Student>()
            {
                new Student{ Id=1, Name="Parth", Course="AI"},
                new Student{ Id=2, Name="Rahul", Course="Data Science"},
                new Student{ Id=3, Name="Anita", Course="Cyber Security"}
            };

            ViewBag.Logs = _logService.GetLogs();

            return View(students);
        }
    }
}