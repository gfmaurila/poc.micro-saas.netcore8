namespace Common.Core._08.Model;

/// <summary>
/// Represents a simple notification with a message.
/// </summary>
public class Notification
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Notification"/> class with the specified message.
    /// </summary>
    /// <param name="message">The message associated with the notification.</param>
    public Notification(string message)
    {
        Message = message;
    }

    /// <summary>
    /// Gets the message associated with the notification.
    /// </summary>
    public string Message { get; }
}

