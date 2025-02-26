using API.Exemple.Core._08.Feature.Domain.Common;
using API.Exemple1.Core._08.Feature.Domain.Exemple.Events.Messaging;
using Common.Core._08.Interface;
using System.Text;
using System.Text.Json;

namespace API.Exemple1.Core._08.Feature.Exemple.Commands.Update.Events.Messaging.RabbiMQ;

/// <summary>
/// Handles publishing events related to the update of an Exemple entity.
/// This class sends messages to a message bus (e.g., RabbitMQ, Kafka).
/// </summary>
public class UpdateExemplePublish : IUpdateExemplePublish
{
    private readonly IMessageBusService _messageBusService;
    private readonly IConfiguration _configuration;
    private readonly ILogger<UpdateExemplePublish> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateExemplePublish"/> class.
    /// </summary>
    /// <param name="messageBusService">Message bus service used for publishing events.</param>
    /// <param name="configuration">Configuration instance to retrieve environment settings.</param>
    /// <param name="logger">Logger instance for logging operations.</param>
    public UpdateExemplePublish(IMessageBusService messageBusService, IConfiguration configuration, ILogger<UpdateExemplePublish> logger)
    {
        _messageBusService = messageBusService;
        _configuration = configuration;
        _logger = logger;
    }

    /// <summary>
    /// Publishes an event related to the update of an Exemple entity to the message queue.
    /// </summary>
    /// <param name="eventData">The event data containing details of the updated Exemple entity.</param>
    public void PublishAsync(ExempleUpdateEvent eventData)
    {
        const string queueName = ExempleEventConstants.EventExempleUpdate;

        _logger.LogInformation("Publishing Exemple update event to queue: {QueueName}", queueName);

        var eventInfoJson = JsonSerializer.Serialize(eventData);
        var eventInfoBytes = Encoding.UTF8.GetBytes(eventInfoJson);

        _messageBusService.Publish(queueName, eventInfoBytes);

        _logger.LogInformation("Exemple update event successfully published to queue: {QueueName}", queueName);
    }
}
