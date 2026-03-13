using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class StudentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}