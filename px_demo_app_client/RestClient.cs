using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Threading.Tasks;

namespace px_demo_app_client
{
    public enum HttpRequests
    {
        GET,
        POST,
        PUT,
        DELETE
    };

    class RestClient
    {

        #region GETTERS_AND_SETTERS

        public string EndPoint { get; set; }
        public HttpRequests HttpRequest { get; set; }

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Creates a RestClient instance with a default GET HttpRequest.
        /// </summary>
        public RestClient()
        {
            EndPoint = string.Empty;
            HttpRequest = HttpRequests.GET;
        }

        /// <summary>
        /// Creates a RestClient instance with a default GET HttpRequest.
        /// </summary>
        /// <param name="endPoint">Assigns a string value to the endPoint property.</param>
        public RestClient(string endPoint)
        {
            EndPoint = endPoint;
            HttpRequest = HttpRequests.GET;
        }

        /// <summary>
        /// Creates a RestClient instance.
        /// </summary>
        /// <param name="endPoint">Assigns a string value to the endPoint property.</param>
        /// <param name="httpRequest">Assigns a HttpRequests enum value to the HttpRequest property.</param>
        public RestClient(string endPoint, HttpRequests httpRequest)
        {
            EndPoint = endPoint;
            HttpRequest = httpRequest;
        }

        #endregion CONSTRUCTORS

        #region METHODS

        public string MakeRequest()
        {
            string resultString = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(EndPoint);

            request.Method = HttpRequest.ToString();

            HttpWebResponse response = null;

            try
            {
                response = (HttpWebResponse)request.GetResponse();

                using (Stream responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            resultString = reader.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return "Exception: \n" + ex.Message;
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                }
            }

            return resultString;
        }

        public string MakeRequest(string endpoint, HttpRequests request)
        {
            EndPoint = endpoint;
            HttpRequest = request;

            return MakeRequest();
        }

        #endregion METHODS

    }
}
