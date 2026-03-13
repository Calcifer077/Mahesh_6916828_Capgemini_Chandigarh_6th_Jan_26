namespace LibraryManagementSystem.Services
{
    public class AuthService : IAuthService
    {
        public bool IsAuthenticated(HttpContext context)
        {
            // Example: check session or cookie
            return context.Session.GetString("User") != null;
        }
    }
}