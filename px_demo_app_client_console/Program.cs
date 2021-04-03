using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text;

namespace px_demo_app_client_console
{

    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        private static int app_id;
        private static string app_name;
        private static List<LogMessage> messages = new List<LogMessage>();
        private static readonly string APIport = "5001";

        static async Task Main(string[] args)
        {
            app_name = EnterAppName();
            int appId = await GetAppId(app_name);

            switch (appId)
            {
                case -1:
                    await AddApp(app_name);
                    break;
                case -2:
                    Console.WriteLine("Problem with server, please try again later.");
                    return;
                default:
                     app_id = appId;
                    break;
            }

            //EnterMessages(ref messages);
           // await SendMessages();
            for (int i = 1; i <= 1500; i++)
            {
                messages.Add(new LogMessage(app_id,DateTime.Now,"MessageTest",LogMessage.LogLevels.info));
            }



            DateTime d1;
            TimeSpan s;
            d1 = DateTime.Now;
            await SendMessages();
            s = DateTime.Now - d1;
            Console.WriteLine(s);

        }

        private static async Task SendMessages() {

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            using (HttpClientHandler clientHandler = new HttpClientHandler())
            {
                clientHandler.
                    ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };

                string json = JsonSerializer.Serialize(messages.ToArray());
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                Console.WriteLine(json);
                HttpResponseMessage rm = await client.PostAsync("https://localhost:" + APIport + "/Px/postlog/", content);
            }

        }

        private static async Task AddApp(string app_name)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            using (HttpClientHandler clientHandler = new HttpClientHandler())
            {
                clientHandler.
                    ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                
                HttpResponseMessage rm  = await client.PostAsync("https://localhost:" + APIport + "/Px/postapp/" + app_name, null);
                
                if ((int)rm.StatusCode == 200)
                    app_id = int.Parse(await rm.Content.ReadAsStringAsync());
            }
        }

        /// <summary>
        /// Gets application ID.
        /// </summary>
        /// <param name="appName">Application name.</param>
        /// <returns>Returns -1 if application does not exist.
        /// Returns -2 if an error occured.</returns>
        private static async Task<int> GetAppId(string app_name)
        {
            int result = -2;
            string stringTask = string.Empty;

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("text/plain"));

            using (HttpClientHandler clientHandler = new HttpClientHandler())
            {
                clientHandler.
                    ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                stringTask = (await client.GetStringAsync("https://localhost:" + APIport + "/Px/getapp/" + app_name)).ToString();
            }


            int.TryParse(stringTask, out result);

            return result;
        }

        private static void EnterMessages(ref List<LogMessage> messages)
        {

            while (true)
            {
                Console.WriteLine("Add new message? (y/n)");
                if (Console.ReadLine() == "n")
                    break;

                LogMessage result = null;

                DateTime logDateValue = DateTime.UtcNow;

                Console.WriteLine("Message:");

                string logMessageValue = Console.ReadLine();
                LogMessage.LogLevels logLevel = LogMessage.LogLevels.info;

                if (LogLevelIncluded(logMessageValue))
                {
                    string logLevelStr = GetLogLevelString(logMessageValue);

                    if (!LogLevelInputValid(logLevelStr))
                    {
                        Console.WriteLine("Log level input is invalid.");
                        continue;
                    }

                    logLevel = (LogMessage.LogLevels)
                        Enum.Parse(typeof(LogMessage.LogLevels), logLevelStr);

                    logMessageValue = GetLogMessageWithoutLevel(logMessageValue);
                }

                result =
                   new LogMessage(app_id, logDateValue, logMessageValue, logLevel);

                if (result != null)
                    messages.Add(result);
            }
        }

        private static string EnterAppName()
        {
            Console.WriteLine("Application name:");
            return Console.ReadLine();
        }

        private static bool LogLevelIncluded(string message)
            => message.StartsWith("[") && message.Contains(']');

        private static bool LogLevelInputValid(string text)
            => Enum.GetNames(typeof(LogMessage.LogLevels))
            .ToList().Exists(x => x.Equals(text));

        private static string GetLogLevelString(string message)
        {
            int firstIndex = message.IndexOf('[');
            int lastIndex = message.IndexOf(']');
            return message.Substring(firstIndex + 1, lastIndex - 1).ToLower();
        }

        private static string GetLogMessageWithoutLevel(string message)
         => message.Split(']')[1];
    }
}
