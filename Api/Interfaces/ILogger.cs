namespace Api.Interfaces
{
    public interface ILogger
    {
        void LogError(string message);
        void LogSuccess(string message);
        void LogInfo(string message);
    }
}
