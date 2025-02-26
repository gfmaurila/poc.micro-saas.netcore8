using Common.Core._08.Model;

namespace Common.Core._08.Interface;

/// <summary>
/// Defines methods for handling notifications, managing their storage, and checking their existence.
/// </summary>
public interface INotificationHandle
{
    /// <summary>
    /// Checks if there are any notifications currently stored.
    /// </summary>
    /// <returns>
    /// <c>true</c> if there are notifications; otherwise, <c>false</c>.
    /// </returns>
    bool IsNotification();

    /// <summary>
    /// Retrieves all stored notifications.
    /// </summary>
    /// <returns>A list of stored notifications.</returns>
    List<Notification> GetNotification();

    /// <summary>
    /// Handles and stores a new notification.
    /// </summary>
    /// <param name="notification">The notification to be handled.</param>
    void Handle(Notification notification);
}

