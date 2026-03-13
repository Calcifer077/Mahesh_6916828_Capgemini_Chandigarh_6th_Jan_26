using LibraryManagementSystem.Services;

namespace LibraryManagementSystem.Middleware
{
    public class AdminAuthMiddleware
    {
        private readonly RequestDelegate _next;

        public AdminAuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IAuthService authService)
        {
            // Check if route starts with /Admin
            if (context.Request.Path.StartsWithSegments("/Admin"))
            {
                if (!authService.IsAuthenticated(context))
                {
                    context.Response.Redirect("/Account/Login");
                    return;
                }
            }

            await _next(context);
        }
    }
}