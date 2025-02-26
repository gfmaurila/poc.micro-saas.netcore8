using API.Exemple1.Core._08.Infrastructure.Messaging;
using Common.Core._08.Interface;
using RabbitMQ.Client;

namespace API.Clinic.Infrastructure.Messaging.RabbiMQ;

/// <summary>
/// Provides message publishing capabilities to a message bus (e.g., RabbitMQ).
/// This service establishes connections to the message broker and sends messages to a specified queue.
/// </summary>
public class MessageBusService : IMessageBusService
{
    private readonly ConnectionFactory _connectionFactory;
    private readonly IConfiguration _configuration;

    /// <summary>
    /// Initializes a new instance of the <see cref="MessageBusService"/> class.
    /// </summary>
    /// <param name="configuration">Configuration instance for retrieving message broker settings.</param>
    public MessageBusService(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionFactory = new ConnectionFactory
        {
            HostName = _configuration.GetValue<string>(MessagingConsts.Hostname),
            Port = Convert.ToInt32(_configuration.GetValue<string>(MessagingConsts.Port)),
            UserName = _configuration.GetValue<string>(MessagingConsts.Username),
            Password = _configuration.GetValue<string>(MessagingConsts.Password)
        };
    }

    /// <summary>
    /// Publishes a message to the specified queue.
    /// </summary>
    /// <param name="queue">The name of the queue to publish the message to.</param>
    /// <param name="message">The message to be published, in byte array format.</param>
    public void Publish(string queue, byte[] message)
    {
        using var connection = _connectionFactory.CreateConnection();
        using var channel = connection.CreateModel();

        // Declare queue if it does not exist
        channel.QueueDeclare(
            queue: queue,
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null);

        // Publish message to queue
        channel.BasicPublish(
            exchange: "",
            routingKey: queue,
            basicProperties: null,
            body: message);
    }
}
