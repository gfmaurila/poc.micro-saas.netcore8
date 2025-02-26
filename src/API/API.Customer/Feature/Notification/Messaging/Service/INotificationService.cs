using API.Exemple1.Core._08.Feature.Notification.Messaging.Request;

namespace API.Exemple1.Core._08.Feature.Notification.Messaging.Service;

public interface INotificationService
{
    Task NotificationAsync(NotificationRequest dto);
}
