using Api.Interfaces;
using Api.Enums;

namespace Api.Utils
{
    public class LogHelper : ILogHelper
    {
        // Declare instance of logger
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(
            System.Reflection.MethodBase.GetCurrentMethod().DeclaringType
            );

        // Logs a single message of a specific type
        public void LogMessage(LogMessageType messageType, string message)
        {
            switch ((int)messageType)
            {
                case 0: log.Debug(message); break;
                case 1: log.Info(message); break;
                case 2: log.Warn(message); break;
                case 3: log.Error(message); break;
                case 4: log.Fatal(message); break;
            }
        }

        // Logs multiple messages of the same type
        public void LogMessages(LogMessageType messageType, string[] messages)
        {
            foreach (string message in messages)
            {
                switch ((int)messageType)
                {
                    case 0: log.Debug(message); break;
                    case 1: log.Info(message); break;
                    case 2: log.Warn(message); break;
                    case 3: log.Error(message); break;
                    case 4: log.Fatal(message); break;
                }
            }
        }
    }
}