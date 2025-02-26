using API.Customer.Infrastructure.Integration.ExternalEmail;
using API.Customer.Infrastructure.Integration.ExternalEmail.Model;
using API.Customer.Infrastructure.Integration.ExternalEmail.Service;
using API.Exemple1.Core._08.Feature.Notification.Messaging.Events;
using API.Exemple1.Core._08.Feature.Notification.Messaging.Request;
using API.Exemple1.Core._08.Infrastructure.Messaging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace API.Customer.Feature.Notification.Messaging.RabbiMQ.Subscribe;

/// <summary>
/// Background service that subscribes to a RabbitMQ queue and processes incoming notification messages.
/// </summary>
public class NotificationRabbiMQSubscribe : BackgroundService
{
    private readonly IConnection _connection;
    private readonly IConfiguration _configuration;
    private readonly IModel _channel;
    private readonly IServiceProvider _serviceProvider;

    /// <summary>
    /// Initializes a new instance of the <see cref="NotificationRabbiMQSubscribe"/> class.
    /// </summary>
    /// <param name="servicesProvider">Service provider instance for dependency injection.</param>
    /// <param name="configuration">Configuration instance for retrieving RabbitMQ credentials.</param>
    public NotificationRabbiMQSubscribe(IServiceProvider servicesProvider, IConfiguration configuration)
    {
        _serviceProvider = servicesProvider;
        _configuration = configuration;

        var factory = new ConnectionFactory
        {
            HostName = _configuration.GetValue<string>(MessagingConsts.Hostname),
            Port = Convert.ToInt32(_configuration.GetValue<string>(MessagingConsts.Port)),
            UserName = _configuration.GetValue<string>(MessagingConsts.Username),
            Password = _configuration.GetValue<string>(MessagingConsts.Password)
        };

        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();

        _channel.QueueDeclare(
            queue: NotificationEventConstants.EventNotificationCreate,
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null);
    }

    /// <summary>
    /// Executes the RabbitMQ consumer, listening for messages asynchronously.
    /// </summary>
    /// <param name="stoppingToken">Cancellation token to handle graceful shutdown.</param>
    /// <returns>A completed task.</returns>
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += async (sender, eventArgs) =>
        {
            var infoBytes = eventArgs.Body.ToArray();
            var infoJson = Encoding.UTF8.GetString(infoBytes);
            var info = JsonSerializer.Deserialize<NotificationRequest>(infoJson);
            await SendNotification(info);
            _channel.BasicAck(eventArgs.DeliveryTag, false);
        };
        _channel.BasicConsume(NotificationEventConstants.EventNotificationCreate, false, consumer);
        return Task.CompletedTask;
    }

    /// <summary>
    /// Processes a received notification and sends it using an external email service.
    /// </summary>
    /// <param name="dto">The notification request containing recipient and message details.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task SendNotification(NotificationRequest dto)
    {
        using var scope = _serviceProvider.CreateScope();
        var sendService = scope.ServiceProvider.GetRequiredService<IExternalEmailService>();

        var request = new CreateSendRequest
        {
            Auth = new ExternalEmailAuth
            {
                AccountSid = _configuration.GetValue<string>(ExternalEmailApiConsts.AccountSid),
                AuthToken = _configuration.GetValue<string>(ExternalEmailApiConsts.AuthToken),
                From = _configuration.GetValue<string>(ExternalEmailApiConsts.From),
            },
            Body = dto.Body,
            To = dto.To,
            Notification = 1
        };

        await sendService.SendMessageAsync(request);
    }
}


