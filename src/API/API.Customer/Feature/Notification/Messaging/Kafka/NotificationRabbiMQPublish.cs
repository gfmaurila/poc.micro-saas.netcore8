using API.Exemple1.Core._08.Feature.Notification.Messaging.Events;
using API.Exemple1.Core._08.Infrastructure.Messaging;
using Confluent.Kafka;
using Newtonsoft.Json;

namespace API.Exemple1.Core._08.Feature.Notification.Messaging.Kafka;

/// <summary>
/// Handles publishing notifications to a Kafka topic.
/// </summary>
public class NotificationKafkaPublish : INotificationKafkaPublish
{
    private readonly ILogger<NotificationKafkaPublish> _logger;
    private readonly ProducerConfig _config;
    private readonly IConfiguration _configuration;

    /// <summary>
    /// Initializes a new instance of the <see cref="NotificationKafkaPublish"/> class.
    /// </summary>
    /// <param name="configuration">Configuration settings for Kafka.</param>
    /// <param name="logger">Logger instance for logging operations.</param>
    public NotificationKafkaPublish(IConfiguration configuration, ILogger<NotificationKafkaPublish> logger)
    {
        _configuration = configuration;
        _config = new ProducerConfig
        {
            BootstrapServers = _configuration.GetValue<string>(MessagingConsts.HostnameKafka)
        };
        _logger = logger;
    }

    /// <summary>
    /// Publishes a notification event to a Kafka topic.
    /// </summary>
    /// <param name="notification">The notification event to publish.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task PublishAsync(NotificationEvent notification)
    {
        _logger.LogInformation("Notification > Kafka > Publish > START");

        using var producer = new ProducerBuilder<Null, string>(_config).Build();
        var message = JsonConvert.SerializeObject(notification);

        await producer.ProduceAsync(
            NotificationEventConstants.EventNotificationCreate,
            new Message<Null, string> { Value = message });

        producer.Flush(TimeSpan.FromSeconds(10));

        _logger.LogInformation("Notification > Kafka > Publish > END");
    }
}
