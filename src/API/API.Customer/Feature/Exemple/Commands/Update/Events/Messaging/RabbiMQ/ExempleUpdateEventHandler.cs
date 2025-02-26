using API.Customer.Feature.Notification;
using API.Customer.Infrastructure.Integration;
using API.Exemple1.Core._08.Feature.Domain.Exemple.Events.Messaging;
using Common.Core._08.Domain.Enumerado;
using Common.Core._08.Helper;
using MediatR;

namespace API.Exemple1.Core._08.Feature.Exemple.Commands.Update.Events.Messaging.RabbiMQ;

/// <summary>
/// Handles the <see cref="ExempleUpdateEvent"/> by sending notifications via RabbitMQ
/// and publishing the event to the messaging system.
/// </summary>
public class ExempleUpdateEventHandler : INotificationHandler<ExempleUpdateEvent>
{
    private readonly IMediator _mediator;
    private readonly IConfiguration _configuration;
    private readonly IUpdateExemplePublish _producer;

    /// <summary>
    /// Initializes a new instance of the <see cref="ExempleUpdateEventHandler"/> class.
    /// </summary>
    /// <param name="mediator">Mediator instance for sending commands to other handlers.</param>
    /// <param name="configuration">Configuration instance for retrieving external service settings.</param>
    /// <param name="producer">Event publisher for sending messages to RabbitMQ.</param>
    public ExempleUpdateEventHandler(IMediator mediator, IConfiguration configuration, IUpdateExemplePublish producer)
    {
        _mediator = mediator;
        _configuration = configuration;
        _producer = producer;
    }

    /// <summary>
    /// Handles the Exemple update event by sending email and WhatsApp notifications via RabbitMQ
    /// and publishing the event without accessing external services.
    /// </summary>
    /// <param name="request">The event data containing details of the updated Exemple entity.</param>
    /// <param name="cancellationToken">Cancellation token to handle task cancellation.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task Handle(ExempleUpdateEvent request, CancellationToken cancellationToken)
    {
        // Sends email and WhatsApp notifications via RabbitMQ
        await EmailRabbiMQAppCommand(request);
        await WhatsAppRabbiMQAppCommand(request);

        // Publishes the event to RabbitMQ without accessing external services
        _producer.PublishAsync(request);
    }

    /// <summary>
    /// Sends an email notification through RabbitMQ.
    /// </summary>
    /// <param name="request">The event data containing the email notification details.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    private async Task EmailRabbiMQAppCommand(ExempleUpdateEvent request)
    {
        await _mediator.Send(new CreateNotificationCommand(
            ENotificationType.Email,
            _configuration.GetValue<string>(ApiConsts.From),
            EmailHelper.GeneratMessage(),
            request.Email));
    }

    /// <summary>
    /// Sends a WhatsApp notification through RabbitMQ.
    /// </summary>
    /// <param name="request">The event data containing the WhatsApp notification details.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    private async Task WhatsAppRabbiMQAppCommand(ExempleUpdateEvent request)
    {
        await _mediator.Send(new CreateNotificationCommand(
            ENotificationType.WhatsApp,
            _configuration.GetValue<string>(ApiConsts.From),
            EmailHelper.GeneratMessage(),
            request.Email));
    }
}
