using API.Exemple1.Core._08.Feature.Domain.Exemple.Events.Messaging;
using API.Person.Feature.Notification;
using API.Person.Infrastructure.Integration;
using Common.Core._08.Domain.Enumerado;
using Common.Core._08.Helper;
using MediatR;

namespace API.Exemple1.Core._08.Feature.Exemple.Commands.Delete.Events.Messaging;

/// <summary>
/// Handles the <see cref="ExempleDeleteEvent"/> by sending notifications via RabbitMQ
/// and publishing the event to the messaging system.
/// </summary>
public class ExempleDeleteEventHandler : INotificationHandler<ExempleDeleteEvent>
{
    private readonly IMediator _mediator;
    private readonly IConfiguration _configuration;
    private readonly IDeleteExemplePublish _producer;

    /// <summary>
    /// Initializes a new instance of the <see cref="ExempleDeleteEventHandler"/> class.
    /// </summary>
    /// <param name="mediator">Mediator instance for sending commands to other handlers.</param>
    /// <param name="configuration">Configuration instance for retrieving external service settings.</param>
    /// <param name="producer">Event publisher for sending messages to RabbitMQ.</param>
    public ExempleDeleteEventHandler(IMediator mediator, IConfiguration configuration, IDeleteExemplePublish producer)
    {
        _mediator = mediator;
        _configuration = configuration;
        _producer = producer;
    }

    /// <summary>
    /// Handles the Exemple deletion event by sending email and WhatsApp notifications via RabbitMQ
    /// and publishing the event without accessing external services.
    /// </summary>
    /// <param name="request">The event data containing details of the deleted Exemple entity.</param>
    /// <param name="cancellationToken">Cancellation token to handle task cancellation.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task Handle(ExempleDeleteEvent request, CancellationToken cancellationToken)
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
    private async Task EmailRabbiMQAppCommand(ExempleDeleteEvent request)
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
    private async Task WhatsAppRabbiMQAppCommand(ExempleDeleteEvent request)
    {
        await _mediator.Send(new CreateNotificationCommand(
            ENotificationType.WhatsApp,
            _configuration.GetValue<string>(ApiConsts.From),
            EmailHelper.GeneratMessage(),
            request.Email));
    }
}
