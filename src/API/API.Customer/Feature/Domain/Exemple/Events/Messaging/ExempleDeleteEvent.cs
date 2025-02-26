using API.Customer.Feature.Domain.Exemple.Events;
using Common.Core._08.Domain.Enumerado;

namespace API.Exemple1.Core._08.Feature.Domain.Exemple.Events.Messaging;

/// <summary>
/// Represents an event triggered when an Exemple entity is deleted.
/// </summary>
public class ExempleDeleteEvent : ExempleBaseEvent
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ExempleDeleteEvent"/> class.
    /// </summary>
    /// <param name="id">The unique identifier of the deleted Exemple entity.</param>
    /// <param name="firstName">The first name of the deleted Exemple entity.</param>
    /// <param name="lastName">The last name of the deleted Exemple entity.</param>
    /// <param name="gender">The gender of the deleted Exemple entity.</param>
    /// <param name="notification">The notification type associated with the deleted Exemple entity.</param>
    /// <param name="email">The email address of the deleted Exemple entity.</param>
    /// <param name="phone">The phone number of the deleted Exemple entity.</param>
    /// <param name="role">The list of roles associated with the deleted Exemple entity.</param>
    public ExempleDeleteEvent(Guid id, string firstName, string lastName, EGender gender, ENotificationType notification, string email, string phone, List<string> role)
        : base(id, firstName, lastName, gender, notification, email, phone, role)
    {
        AggregateId = Guid.NewGuid();
        MessageType = nameof(ExempleDeleteEvent);
    }
}
