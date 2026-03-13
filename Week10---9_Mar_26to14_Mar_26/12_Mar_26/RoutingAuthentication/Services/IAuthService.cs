namespace LibraryManagementSystem.Services
{
    public interface IAuthService
    {
        bool IsAuthenticated(HttpContext context);
    }
}