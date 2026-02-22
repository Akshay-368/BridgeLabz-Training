using System;
using System.IO;

namespace SmartCitySmartCity.Utilities
{
    public static class ExceptionLogger
    {
        private static readonly string LogFile = "error_log.txt";

        public static void Log(Exception ex)
        {
            string message = $"{DateTime.Now} | {ex.GetType().Name} | {ex.Message}";
            File.AppendAllText(LogFile, message + Environment.NewLine);
        }
    }
}
