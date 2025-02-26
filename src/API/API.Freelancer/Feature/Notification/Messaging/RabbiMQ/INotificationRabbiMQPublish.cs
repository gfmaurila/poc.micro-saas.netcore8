using API.Exemple1.Core._08.Feature.Notification.Messaging.Events;

namespace API.Exemple1.Core._08.Feature.Notification.Messaging.RabbiMQ;

public interface INotificationRabbiMQPublish
{
    void PublishAsync(NotificationEvent events);
}
