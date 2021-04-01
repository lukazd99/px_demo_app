using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace px_demo_app_client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            logMessageDate.Value = DateTime.Now;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            DateTime logDateValue = logMessageDate.Value;
            string logMessageValue = logMessageText.Text;
            LogMessage.LogLevels logLevel = LogMessage.LogLevels.info;

            if (LogLevelIncluded(logMessageValue))
            {
                string logLevelStr = GetLogLevelString(logMessageValue);
                if (!LogLevelInputValid(logLevelStr))
                {
                    MessageBox.Show("Log level input is not valid.");
                    return;
                }

                logLevel = (LogMessage.LogLevels)
                    Enum.Parse(typeof(LogMessage.LogLevels), logLevelStr);

                logMessageValue = GetLogMessageWithoutLevel(logMessageValue);
            }

            LogMessage logMessage =
                new LogMessage(logDateValue, Application.ProductName,
                logMessageValue, logLevel);

            MessageBox.Show(logMessage.ToString());
        }

        private bool LogLevelIncluded(string message) 
            => message[0].Equals('[') || message.StartsWith(" [");

        private bool LogLevelInputValid(string text)
            => Enum.GetNames(typeof(LogMessage.LogLevels))
            .ToList().Exists(x => x.Equals(text));

        private string GetLogLevelString(string message)
        {
            int firstIndex = message.IndexOf('[');
            int lastIndex = message.IndexOf(']');
            return message.Substring(firstIndex + 1, lastIndex - 1).ToLower();
        }

        private string GetLogMessageWithoutLevel(string message)
         => message.Split(']')[1];
    }
}
