using System.Diagnostics;
namespace Api.LogMessage {
    public class DataBaseLogger : ILogMessage {
        public void WriteToLog(string message) {
            // Write log to database whether by direct access or a microservice to another API.

        }
    }
    public class EventLogLogger : ILogMessage {
        public void WriteToLog(string message) {
            // Write log to Windows Event Log - too slow and inefficient to use when deployed but useful during development.
            // Need permissions granting so this can work.

            //EventLog eventLog = new EventLog("Application");
            //eventLog.Source = "Fund API";
            //if (!EventLog.SourceExists(eventLog.Source)) {
            //    EventLog.CreateEventSource(eventLog.Source, eventLog.Log);
            //}
            //eventLog.WriteEntry(message, EventLogEntryType.Information, 101, 1);

        }
    }
}