using System;
using System.Diagnostics;

namespace MicMuter
{
    public static class Logger
    {
        private static TraceSource trace = new TraceSource(Configuration.AppName, SourceLevels.Warning);

        public static void LogMessage(TraceEventType level, string message)
        {
            var timeStamp = DateTime.Now.ToString("HH:mm:ss.ffff");
            var logMessage = $"[{timeStamp}] {message}";
            trace.TraceEvent(level, 0, $"[{timeStamp}] {message}");
            Debug.WriteLine($"[{timeStamp}] [{level,11}] {message}");
        }

        public static void LogException(Exception exception)
        {
            LogMessage(TraceEventType.Error, exception.ToString());
        }
    }
}