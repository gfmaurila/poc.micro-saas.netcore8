using API.Exemple1.Core._08.Feature.Notification.Messaging.Events;
using API.Exemple1.Core._08.Feature.Notification.Messaging.Kafka.Subscribe;
using Common.Core._08.Kafka;

namespace API.InventoryControl.Feature.Notification.Messaging.Kafka.Subscribe;


public class NotificationKafkaSubscribe : IHostedService
{
    private readonly ILogger<NotificationKafkaSubscribe> _logger;
    private readonly IKafkaConsumer _kafkaConsumer;
    private readonly IServiceScopeFactory _scopeFactory;

    /// <summary>
    /// Initializes a new instance of the <see cref="NotificationKafkaSubscribe"/> class.
    /// </summary>
    /// <param name="kafkaConsumer">Kafka consumer instance for message processing.</param>
    /// <param name="scopeFactory">Factory for creating scoped service instances.</param>
    /// <param name="logger">Logger instance for logging operations.</param>
    public NotificationKafkaSubscribe(
        IKafkaConsumer kafkaConsumer,
        IServiceScopeFactory scopeFactory,
        ILogger<NotificationKafkaSubscribe> logger)
    {
        _kafkaConsumer = kafkaConsumer;
        _scopeFactory = scopeFactory;
        _logger = logger;
    }

    /// <summary>
    /// Starts the Kafka consumer service asynchronously.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token to signal task cancellation.</param>
    /// <returns>A completed task.</returns>
    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Starting Kafka Consumer...");

        Task.Run(() => ConsumeMessagesAsync(cancellationToken), cancellationToken);

        return Task.CompletedTask;
    }

    /// <summary>
    /// Consumes messages from the Kafka topic and processes them asynchronously.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token to signal task cancellation.</param>
    private async Task ConsumeMessagesAsync(CancellationToken cancellationToken)
    {
        await _kafkaConsumer.ConsumeAsync(
            new List<string> { NotificationEventConstants.EventNotificationCreate },
            NotificationEventConstants.EventNotificationExemple,
            async message =>
            {
                using var scope = _scopeFactory.CreateScope();
                var messageProcessor = scope.ServiceProvider.GetRequiredService<INotificationMessageProcessor>();
                await messageProcessor.ProcessMessageAsync(message);
            },
            cancellationToken);
    }

    /// <summary>
    /// Stops the Kafka consumer service asynchronously.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token to signal task cancellation.</param>
    /// <returns>A completed task.</returns>
    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Stopping Kafka Consumer...");
        return Task.CompletedTask;
    }
}



