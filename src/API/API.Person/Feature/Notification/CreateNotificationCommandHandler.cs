using API.Exemple1.Core._08.Feature.Notification.Messaging.Events;
using API.Exemple1.Core._08.Feature.Notification.Messaging.RabbiMQ;
using Common.Core._08.Response;
using MediatR;

namespace API.Person.Feature.Notification;

public class CreateNotificationCommandHandler : IRequestHandler<CreateNotificationCommand, ApiResult<CreateNotificationResponse>>
{
    private readonly ILogger<CreateNotificationCommandHandler> _logger;
    private readonly INotificationRabbiMQPublish _producer;

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateNotificationCommandHandler"/> class.
    /// </summary>
    /// <param name="logger">Logger instance for logging operations.</param>
    /// <param name="producer">RabbitMQ producer instance for sending notifications.</param>
    /// <param name="producerKafka">Kafka producer instance for sending notifications.</param>
    public CreateNotificationCommandHandler(
        ILogger<CreateNotificationCommandHandler> logger,
        INotificationRabbiMQPublish producer)
    {
        _logger = logger;
        _producer = producer;
    }

    /// <summary>
    /// Handles the notification command, sending messages through Kafka and RabbitMQ.
    /// </summary>
    /// <param name="request">The notification command containing the message details.</param>
    /// <param name="cancellationToken">Cancellation token for task cancellation.</param>
    /// <returns>A result containing the response and operation status.</returns>
    public async Task<ApiResult<CreateNotificationResponse>> Handle(CreateNotificationCommand request, CancellationToken cancellationToken)
    {
        // Send notification via RabbitMQ
        _logger.LogInformation("CreateNotificationCommand => RabbitMQ");
        _producer.PublishAsync(new NotificationEvent(
            request.Notification,
            $"RabbitMQ => {request.From}",
            $"RabbitMQ => {request.Body}",
            request.To,
            Guid.NewGuid()));

        return ApiResult<CreateNotificationResponse>.CreateSuccess(
            new CreateNotificationResponse(Guid.NewGuid()), "Message sent successfully");
    }
}
