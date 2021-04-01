using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace px_demo_app_client
{
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

        private DateTime date;
        private string appName;
        private string message;
        private LogLevels logLevel;

        public LogMessage(DateTime date, string appName, string message, LogLevels logLevel)
        {
            this.date = date;
            this.appName = appName;
            this.message = message;
            this.logLevel = logLevel;
        }

        public override string ToString()
        {
            return "Date: " + date + "\n" + "Name: " + appName + "\n" 
                + "Message: " + message + "\n" + "Log Level: " + logLevel.ToString();
        }
    }
}
