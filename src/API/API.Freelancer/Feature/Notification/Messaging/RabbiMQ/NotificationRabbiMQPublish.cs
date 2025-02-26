using API.Exemple1.Core._08.Feature.Notification.Messaging.Events;
using Common.Core._08.Interface;
using System.Text;
using System.Text.Json;

namespace API.Exemple1.Core._08.Feature.Notification.Messaging.RabbiMQ;

public class NotificationRabbiMQPublish : INotificationRabbiMQPublish
{
    private readonly IMessageBusService _messageBusService;
    private readonly ILogger<NotificationRabbiMQPublish> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="NotificationRabbiMQPublish"/> class.
    /// </summary>
    /// <param name="messageBusService">The message bus service used to publish messages to RabbitMQ.</param>
    /// <param name="logger">Logger instance for logging operations.</param>
    public NotificationRabbiMQPublish(IMessageBusService messageBusService, ILogger<NotificationRabbiMQPublish> logger)
    {
        _messageBusService = messageBusService;
        _logger = logger;
    }

    /// <summary>
    /// Publishes a notification event to a RabbitMQ queue.
    /// </summary>
    /// <param name="notification">The notification event to publish.</param>
    public void PublishAsync(NotificationEvent notification)
    {
        _logger.LogInformation("Notification > RabbitMQ > Publish > START");

        string queueName = NotificationEventConstants.EventNotificationCreate;
        var notificationInfoJson = JsonSerializer.Serialize(notification);
        var notificationInfoBytes = Encoding.UTF8.GetBytes(notificationInfoJson);

        _messageBusService.Publish(queueName, notificationInfoBytes);

        _logger.LogInformation("Notification > RabbitMQ > Publish > END");
    }
}
