using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

public class RequestTrackingMiddleware
{
    private readonly RequestDelegate _next;

    public RequestTrackingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, IRequestLogService logService)
    {
        var stopwatch = Stopwatch.StartNew();

        await _next(context); // process next middleware

        stopwatch.Stop();

        var log = new RequestLog
        {
            Url = context.Request.Path,
            ExecutionTime = stopwatch.ElapsedMilliseconds,
            Time = DateTime.Now
        };

        logService.AddLog(log);
    }
}