using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers.Admin
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}