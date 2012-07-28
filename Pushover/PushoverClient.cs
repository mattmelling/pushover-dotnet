using System;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
using Pushover.Extensions;

namespace Pushover
{
    public class PushoverClient
    {
        private readonly string _apiKey;
        private readonly string _endpoint = "https://api.pushover.net/1/messages.xml";

        /// <summary>
        /// Create a new Pushover client.
        /// </summary>
        /// <param name="apiKey">Your Pushover API key</param>
        public PushoverClient(string apiKey)
        {
            _apiKey = apiKey;
        }

        /// <summary>
        /// Create a new Pushover client
        /// </summary>
        /// <param name="apiKey">Your pushover API key</param>
        /// <param name="endpoint">Alternative XML endpoint to push messages to</param>
        public PushoverClient(string apiKey, string endpoint) : this(apiKey)
        {
            _endpoint = endpoint;
        }
        
        /// <summary>
        /// Read the response out as a string
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        private string GetResponseText(WebResponse response)
        {
            var reader = new StreamReader(response.GetResponseStream());
            return reader.ReadToEnd();
        }

        /// <summary>
        /// Parses an error response and returns an error description
        /// </summary>
        /// <param name="response">Response to parse</param>
        /// <returns></returns>
        private string ProcessErrorResponse(string response)
        {
            var doc = new XmlDocument();
            doc.LoadXml(response);
            
            var buffer = new StringBuilder();
            foreach(XmlNode hash in doc.GetElementsByTagName("hash"))
                foreach(XmlNode child in hash)
                    if (child.Name == "status") continue;
                    else buffer.Append(String.Format("{0} is invalid", child.Name));
            return buffer.ToString();
        }

        /// <summary>
        /// Push a new message 
        /// </summary>
        /// <param name="message">The message to push</param>
        public void Push(IPushoverMessage message)
        {
            if(message == null) throw new ArgumentNullException("message");
            if(String.IsNullOrEmpty(message.User)) throw new ArgumentException("message.User");

            var values = message.GetRequestValues();
            values.Add("token", _apiKey);

            using (var client = new WebClient())
            {
                try
                {
                    client.UploadValues(_endpoint, values);
                }
                catch (WebException wex)
                {
                    var response = GetResponseText(wex.Response);
                    throw new PushoverException(ProcessErrorResponse(response), wex);
                }
            }
        }
    }
}
