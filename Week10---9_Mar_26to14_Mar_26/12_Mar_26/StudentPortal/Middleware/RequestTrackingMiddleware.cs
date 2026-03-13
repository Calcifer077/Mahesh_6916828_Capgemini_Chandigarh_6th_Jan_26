using System.Diagnostics;
using StudentPortal.Services;

namespace StudentPortal.Middleware
{
    public class RequestTrackingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IRequestLogService _logService;

        public RequestTrackingMiddleware(RequestDelegate next, IRequestLogService logService)
        {
            _next = next;
            _logService = logService;
        }

        public async Task Invoke(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();

            await _next(context);

            stopwatch.Stop();

            var url = context.Request.Path;

            _logService.AddLog(url, stopwatch.ElapsedMilliseconds);
        }
    }
}