using StudentPortal.Models;

namespace StudentPortal.Services
{
    public interface IRequestLogService
    {
        void AddLog(string url, long executionTime);
        List<RequestLog> GetLogs();
    }
}