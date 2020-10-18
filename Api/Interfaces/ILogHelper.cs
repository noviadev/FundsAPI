using Api.Enums;

namespace Api.Interfaces
{
    public interface ILogHelper
    {
        void LogMessage(LogMessageType messageType, string message);

        void LogMessages(LogMessageType messageType, string[] messages);
    }
}