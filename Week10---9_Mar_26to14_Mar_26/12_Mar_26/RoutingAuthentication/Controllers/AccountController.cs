using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username)
        {
            HttpContext.Session.SetString("User", username);

            return Redirect("/Admin/Dashboard");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("/Students/Index");
        }
    }
}