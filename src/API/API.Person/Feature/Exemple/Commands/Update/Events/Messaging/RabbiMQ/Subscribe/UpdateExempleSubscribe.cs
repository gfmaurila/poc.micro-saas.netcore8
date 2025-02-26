using API.Person.Feature.Domain.Common;
using MassTransit;

namespace API.Exemple1.Core._08.Feature.Exemple.Commands.Update.Events.Messaging.RabbiMQ.Subscribe;

///// <summary>
///// Background service that subscribes to a RabbitMQ queue and processes Exemple update events.
///// </summary>
//public class UpdateExempleSubscribe : BackgroundService
//{
//    private readonly IConnection _connection;
//    private readonly IConfiguration _configuration;
//    private readonly IModel _channel;

//    /// <summary>
//    /// Initializes a new instance of the <see cref="UpdateExempleSubscribe"/> class.
//    /// </summary>
//    /// <param name="servicesProvider">Service provider instance for dependency injection.</param>
//    /// <param name="configuration">Configuration instance for retrieving RabbitMQ settings.</param>
//    public UpdateExempleSubscribe(IServiceProvider servicesProvider, IConfiguration configuration)
//    {
//        _configuration = configuration;

//        var factory = new ConnectionFactory
//        {
//            HostName = _configuration.GetValue<string>(MessagingConsts.Hostname),
//            Port = Convert.ToInt32(_configuration.GetValue<string>(MessagingConsts.Port)),
//            UserName = _configuration.GetValue<string>(MessagingConsts.Username),
//            Password = _configuration.GetValue<string>(MessagingConsts.Password)
//        };

//        _connection = factory.CreateConnection();
//        _channel = _connection.CreateModel();

//        // Declare queue to ensure it exists before consuming messages
//        _channel.QueueDeclare(
//            queue: ExempleEventConstants.EventExempleUpdate,
//            durable: false,
//            exclusive: false,
//            autoDelete: false,
//            arguments: null);
//    }

//    /// <summary>
//    /// Executes the RabbitMQ consumer, listening for incoming messages asynchronously.
//    /// </summary>
//    /// <param name="stoppingToken">Cancellation token to handle graceful shutdown.</param>
//    /// <returns>A completed task.</returns>
//    protected override Task ExecuteAsync(CancellationToken stoppingToken)
//    {
//        var consumer = new EventingBasicConsumer(_channel);
//        consumer.Received += async (sender, eventArgs) =>
//        {
//            var infoBytes = eventArgs.Body.ToArray();
//            var infoJson = Encoding.UTF8.GetString(infoBytes);
//            var info = JsonSerializer.Deserialize<ExempleConsumer>(infoJson);

//            await SendNotification(info);

//            _channel.BasicAck(eventArgs.DeliveryTag, false);
//        };

//        _channel.BasicConsume(ExempleEventConstants.EventExempleUpdate, false, consumer);

//        return Task.CompletedTask;
//    }

//    /// <summary>
//    /// Processes the received event by handling the Exemple entity update notification.
//    /// </summary>
//    /// <param name="dto">The received event data.</param>
//    /// <returns>A task representing the asynchronous operation.</returns>
//    public async Task SendNotification(ExempleConsumer dto)
//    {
//        // Implement notification logic here
//    }
//}



public class UpdateExempleSubscribe : IConsumer<ExempleConsumer>
{
    private readonly ILogger<UpdateExempleSubscribe> _logger;

    public UpdateExempleSubscribe(ILogger<UpdateExempleSubscribe> logger)
    {
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<ExempleConsumer> context)
    {
        _logger.LogInformation("Received Update Exemple event via MassTransit: {Message}", context.Message);
        await SendNotification(context.Message);
    }

    public async Task SendNotification(ExempleConsumer dto)
    {
        // Implement notification handling logic here.
    }
}
