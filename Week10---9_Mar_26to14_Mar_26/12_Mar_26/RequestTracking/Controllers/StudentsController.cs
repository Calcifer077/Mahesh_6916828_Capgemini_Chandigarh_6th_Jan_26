using Microsoft.AspNetCore.Mvc;
using RequestTracking.Services;

public class StudentsController : Controller
{
    private readonly IRequestLogService _logService;

    public StudentsController(IRequestLogService logService)
    {
        _logService = logService;
    }

    public IActionResult Index()
    {
        var students = new List<string>
        {
            "Rahul",
            "Simran",
            "Amit"
        };

        var logs = _logService.GetLogs();

        var model = new StudentsViewModel
        {
            Students = students,
            Logs = logs
        };

        return View(model);
    }
}