using System;
using System.Collections.Specialized;

namespace Pushover.Extensions
{
    static class MessageExtensions
    {
        /// <summary>
        /// Get a dictionary of request arguments
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static NameValueCollection GetRequestValues(this IPushoverMessage message)
        {
            // Build up the request
            var values = new NameValueCollection
                       {
                           {"user", message.User}, 
                           {"message", message.Message}
                       };

            if (!String.IsNullOrEmpty(message.Device))
                values.Add("device", message.Device);

            if (!String.IsNullOrEmpty(message.Title))
                values.Add("title", message.Title);

            if (!String.IsNullOrEmpty(message.Url))
                values.Add("url", message.Url);

            if (!String.IsNullOrEmpty(message.UrlTitle))
                values.Add("url_title", message.UrlTitle);

            if (message.Priority == MessagePriority.High)
                values.Add("priority", "1");

            if (message.Timestamp != null)
                values.Add("timestamp", message.Timestamp.Value.ToEpoch().ToString());

            return values;
        }
    }
}
