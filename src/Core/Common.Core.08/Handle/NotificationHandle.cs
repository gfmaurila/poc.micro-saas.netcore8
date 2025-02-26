using Common.Core._08.Interface;
using Common.Core._08.Model;

namespace Common.Core._08.Handle;

/// <summary>
/// Handles domain notifications, storing and managing them.
/// </summary>
public class NotificationHandle : INotificationHandle
{
    private List<Notification> _notification;

    /// <summary>
    /// Initializes a new instance of the <see cref="NotificationHandle"/> class.
    /// </summary>
    public NotificationHandle()
    {
        _notification = new List<Notification>();
    }

    /// <summary>
    /// Adds a notification to the list of notifications.
    /// </summary>
    /// <param name="notification">The notification to handle.</param>
    public void Handle(Notification notification)
    {
        _notification.Add(notification);
    }

    /// <summary>
    /// Retrieves the list of all stored notifications.
    /// </summary>
    /// <returns>A list of notifications.</returns>
    public List<Notification> GetNotification()
    {
        return _notification;
    }

    /// <summary>
    /// Checks if there are any notifications stored.
    /// </summary>
    /// <returns>True if there are notifications; otherwise, false.</returns>
    public bool IsNotification()
    {
        return _notification.Any();
    }
}

