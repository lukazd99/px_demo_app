using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace px_demo_app_client_console
{
    [Serializable]
    class LogMessage
    {
        public enum LogLevels
        {
            trace,
            debug,
            info,
            warn,
            error
        };

        public int applicationId { get; set; }
        public DateTime? date { get; set; }
        public string message { get; set; }
        public LogLevels logLevel { get; set; }

        public LogMessage(int applicationId, DateTime date, string message, LogLevels logLevel)
        {
            this.applicationId = applicationId;
            this.date = date;
            this.message = message;
            this.logLevel = logLevel;
        }

        public override string ToString()
        {
            return "Date: " + date + "\n" + "App Id: " + applicationId + "\n" 
                + "Message: " + message + "\n" + "Log Level: " + logLevel.ToString();
        }
    }
}
