namespace API.Exemple1.Core._08.Feature.Notification.Messaging.Kafka.Subscribe;

public interface INotificationMessageProcessor
{
    Task ProcessMessageAsync(string message);
}
