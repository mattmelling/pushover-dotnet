using System;

namespace Pushover
{
    public enum MessagePriority
    {
        Normal,
        High
    }

    public interface IPushoverMessage
    {
        string User { get; }
        string Message { get; }
        string Title { get; }
        string Device { get; }
        string Url { get; }
        string UrlTitle { get; }
        MessagePriority Priority { get; }
        DateTime? Timestamp { get; }
    }
}
