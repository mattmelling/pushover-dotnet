using System;

namespace Pushover
{
    public class PushoverException : Exception
    {
        public PushoverException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }
    }
}
