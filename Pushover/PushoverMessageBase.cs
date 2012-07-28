using System;

namespace Pushover
{
    /// <summary>
    /// Basic implementation of IPushoverMessage 
    /// </summary>
    public class PushoverMessageBase : IPushoverMessage
    {
        #region IMessage Members

        public virtual string User { get; set; }
        public virtual string Message { get; set; }
        public string Title { get; set; }
        public virtual string Device { get; set; }
        public virtual string Url { get; set; }
        public virtual string UrlTitle { get; set; }
        public virtual MessagePriority Priority { get; set; }
        public virtual DateTime? Timestamp { get; set; }

        #endregion
    }
}
