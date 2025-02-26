using API.Clinic.Feature.Notification;
using API.Clinic.Infrastructure.Integration;
using API.Exemple1.Core._08.Feature.Domain.Exemple.Events.Messaging;
using Common.Core._08.Domain.Enumerado;
using Common.Core._08.Helper;
using MediatR;

namespace API.Exemple1.Core._08.Feature.Exemple.Commands.Create.Events.Messaging;

/// <summary>
/// Handles the <see cref="ExempleCreateEvent"/> by sending notifications via RabbitMQ and publishing the event.
/// </summary>
public class ExempleCreateEventHandler : INotificationHandler<ExempleCreateEvent>
{
    private readonly IMediator _mediator;
    private readonly IConfiguration _configuration;
    private readonly ICreateExemplePublish _producer;

    /// <summary>
    /// Initializes a new instance of the <see cref="ExempleCreateEventHandler"/> class.
    /// </summary>
    /// <param name="mediator">Mediator instance for sending commands to other handlers.</param>
    /// <param name="configuration">Configuration instance for retrieving external service settings.</param>
    /// <param name="producer">Event publisher for sending messages to RabbitMQ.</param>
    public ExempleCreateEventHandler(IMediator mediator, IConfiguration configuration, ICreateExemplePublish producer)
    {
        _mediator = mediator;
        _configuration = configuration;
        _producer = producer;
    }

    /// <summary>
    /// Handles the Exemple creation event by sending email and WhatsApp notifications via RabbitMQ
    /// and publishing the event without accessing external services.
    /// </summary>
    /// <param name="request">The event data containing details of the created Exemple entity.</param>
    /// <param name="cancellationToken">Cancellation token to handle task cancellation.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task Handle(ExempleCreateEvent request, CancellationToken cancellationToken)
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
    private async Task EmailRabbiMQAppCommand(ExempleCreateEvent request)
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
    private async Task WhatsAppRabbiMQAppCommand(ExempleCreateEvent request)
    {
        await _mediator.Send(new CreateNotificationCommand(
            ENotificationType.WhatsApp,
            _configuration.GetValue<string>(ApiConsts.From),
            EmailHelper.GeneratMessage(),
            request.Email));
    }
}
