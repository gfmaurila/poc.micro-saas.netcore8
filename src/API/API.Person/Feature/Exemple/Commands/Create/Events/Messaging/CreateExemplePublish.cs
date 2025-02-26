using API.Exemple1.Core._08.Feature.Domain.Exemple.Events.Messaging;
using API.Person.Feature.Domain.Common;
using Common.Core._08.Interface;
using System.Text;
using System.Text.Json;

namespace API.Exemple1.Core._08.Feature.Exemple.Commands.Create.Events.Messaging;

/// <summary>
/// Handles publishing events related to the creation of an Exemple entity.
/// This class publishes messages to a message bus (e.g., RabbitMQ, Kafka).
/// </summary>
public class CreateExemplePublish : ICreateExemplePublish
{
    private readonly IMessageBusService _messageBusService;
    private readonly IConfiguration _configuration;
    private readonly ILogger<CreateExemplePublish> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateExemplePublish"/> class.
    /// </summary>
    /// <param name="messageBusService">Message bus service used for publishing events.</param>
    /// <param name="configuration">Configuration instance to retrieve environment settings.</param>
    /// <param name="logger">Logger instance for logging operations.</param>
    public CreateExemplePublish(IMessageBusService messageBusService, IConfiguration configuration, ILogger<CreateExemplePublish> logger)
    {
        _messageBusService = messageBusService;
        _configuration = configuration;
        _logger = logger;
    }

    /// <summary>
    /// Publishes an event related to the creation of an Exemple entity to the message queue.
    /// </summary>
    /// <param name="eventData">The event data containing details of the created Exemple entity.</param>
    public void PublishAsync(ExempleCreateEvent eventData)
    {
        const string queueName = ExempleEventConstants.EventExempleCreate;

        _logger.LogInformation("Publishing Exemple creation event to queue: {QueueName}", queueName);

        var eventInfoJson = JsonSerializer.Serialize(eventData);
        var eventInfoBytes = Encoding.UTF8.GetBytes(eventInfoJson);

        _messageBusService.Publish(queueName, eventInfoBytes);

        _logger.LogInformation("Exemple creation event successfully published to queue: {QueueName}", queueName);
    }
}
