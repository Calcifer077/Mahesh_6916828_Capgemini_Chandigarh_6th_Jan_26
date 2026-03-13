using RequestTracking.Services;

public class RequestLogService : IRequestLogService
{
    private static List<RequestLog> logs = new List<RequestLog>();

    public void AddLog(RequestLog log)
    {
        logs.Add(log);
    }

    public List<RequestLog> GetLogs()
    {
        return logs;
    }
}