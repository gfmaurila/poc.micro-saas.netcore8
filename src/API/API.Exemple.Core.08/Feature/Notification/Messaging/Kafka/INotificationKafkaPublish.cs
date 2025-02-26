using API.Exemple1.Core._08.Feature.Notification.Messaging.Events;

namespace API.Exemple1.Core._08.Feature.Notification.Messaging.Kafka;

public interface INotificationKafkaPublish
{
    Task PublishAsync(NotificationEvent notification);
}
