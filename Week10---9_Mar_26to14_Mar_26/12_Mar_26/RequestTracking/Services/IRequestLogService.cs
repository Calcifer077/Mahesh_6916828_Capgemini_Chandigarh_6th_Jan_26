namespace RequestTracking.Services
{
    public interface IRequestLogService
    {
        void AddLog(RequestLog log);
        List<RequestLog> GetLogs();
    }
}
