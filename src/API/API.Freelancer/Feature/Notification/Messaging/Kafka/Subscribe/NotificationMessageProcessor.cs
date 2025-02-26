using API.Exemple1.Core._08.Feature.Notification.Messaging.Events;
using API.Exemple1.Core._08.Feature.Notification.Messaging.Request;
using API.Exemple1.Core._08.Feature.Notification.Messaging.Service;
using API.Freelancer.Infrastructure.Integration.ExternalEmail;
using Newtonsoft.Json;

namespace API.Exemple1.Core._08.Feature.Notification.Messaging.Kafka.Subscribe;

public class NotificationMessageProcessor : INotificationMessageProcessor
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly IConfiguration _configuration;
    private readonly ILogger<NotificationMessageProcessor> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="NotificationMessageProcessor"/> class.
    /// </summary>
    /// <param name="scopeFactory">Factory for creating scoped service instances.</param>
    /// <param name="configuration">Configuration instance for retrieving external API credentials.</param>
    /// <param name="logger">Logger instance for logging operations.</param>
    public NotificationMessageProcessor(IServiceScopeFactory scopeFactory, IConfiguration configuration, ILogger<NotificationMessageProcessor> logger)
    {
        _scopeFactory = scopeFactory;
        _configuration = configuration;
        _logger = logger;
    }

    /// <summary>
    /// Processes an incoming notification message by deserializing it and forwarding it to the notification service.
    /// </summary>
    /// <param name="message">The raw JSON message received from Kafka or RabbitMQ.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task ProcessMessageAsync(string message)
    {
        try
        {
            var notificationEvent = JsonConvert.DeserializeObject<NotificationEvent>(message);

            if (notificationEvent != null)
            {
                using var scope = _scopeFactory.CreateScope();
                var notificationService = scope.ServiceProvider.GetRequiredService<INotificationService>();

                var request = new NotificationRequest
                {
                    To = notificationEvent.To,
                    Body = notificationEvent.Body,
                    Notification = notificationEvent.NotificationType,
                    Auth = new AuthNotification
                    {
                        AccountSid = _configuration.GetValue<string>(ExternalEmailApiConsts.AccountSid),
                        AuthToken = _configuration.GetValue<string>(ExternalEmailApiConsts.AuthToken),
                        From = _configuration.GetValue<string>(ExternalEmailApiConsts.From),
                    }
                };

                await notificationService.NotificationAsync(request);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error processing message: {ex.Message}");
        }
    }
}
