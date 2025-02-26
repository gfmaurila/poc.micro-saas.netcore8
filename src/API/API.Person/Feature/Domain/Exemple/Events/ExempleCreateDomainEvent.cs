using API.Exemple1.Core._08.Feature.Exemple.Commands.Create;
using API.Person.Feature.Domain.Exemple.Models;

namespace API.Person.Feature.Domain.Exemple.Events;

/// <summary>
/// Represents a domain event triggered when a new Exemple entity is created.
/// </summary>
public class ExempleCreateDomainEvent : ExempleBaseEvent
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ExempleCreateDomainEvent"/> class.
    /// </summary>
    /// <param name="id">The unique identifier of the created Exemple entity.</param>
    /// <param name="request">The command containing the details of the new Exemple entity.</param>
    /// <param name="model">The model containing audit information for the creation process.</param>
    public ExempleCreateDomainEvent(Guid id,
                                    CreateExempleCommand request,
                                    AuthExempleCreateUpdateDeleteModel model)
        : base(id, request.FirstName, request.LastName, request.Gender, request.Notification, request.Email, request.Phone, request.Role, request.Status, model)
    {
    }
}
