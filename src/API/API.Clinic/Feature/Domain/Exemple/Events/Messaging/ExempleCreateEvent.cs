using API.Clinic.Feature.Domain.Exemple.Events;
using API.Clinic.Feature.Domain.Exemple.Models;
using API.Exemple1.Core._08.Feature.Exemple.Commands.Create;

namespace API.Exemple1.Core._08.Feature.Domain.Exemple.Events.Messaging;

/// <summary>
/// Represents an event triggered when a new Exemple entity is created.
/// </summary>
public class ExempleCreateEvent : ExempleBaseEvent
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ExempleCreateEvent"/> class.
    /// </summary>
    /// <param name="id">The unique identifier of the created Exemple entity.</param>
    /// <param name="request">The command containing the details of the new Exemple entity.</param>
    /// <param name="model">The model containing audit information for creation.</param>
    public ExempleCreateEvent(Guid id,
                              CreateExempleCommand request,
                              AuthExempleCreateUpdateDeleteModel model)
        : base(id, request.FirstName, request.LastName, request.Gender, request.Notification, request.Email, request.Phone, request.Role, request.Status, model)
    {
        AggregateId = Guid.NewGuid();
        MessageType = nameof(ExempleCreateEvent);
    }
}
