using API.Customer.Feature.Domain.Exemple.Models;
using Common.Core._08.Domain.Enumerado;

namespace API.Customer.Feature.Domain.Exemple.Events;

/// <summary>
/// Represents a domain event triggered when an Exemple entity is updated.
/// </summary>
public class ExempleUpdateDomainEvent : ExempleBaseEvent
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ExempleUpdateDomainEvent"/> class.
    /// </summary>
    /// <param name="id">The unique identifier of the updated Exemple entity.</param>
    /// <param name="firstName">The first name of the updated Exemple entity.</param>
    /// <param name="lastName">The last name of the updated Exemple entity.</param>
    /// <param name="gender">The gender of the updated Exemple entity.</param>
    /// <param name="notification">The notification type associated with the updated Exemple entity.</param>
    /// <param name="email">The email address of the updated Exemple entity.</param>
    /// <param name="phone">The phone number of the updated Exemple entity.</param>
    /// <param name="role">The list of roles associated with the updated Exemple entity.</param>
    /// <param name="status">The active/inactive status of the updated Exemple entity.</param>
    /// <param name="model">The model containing audit information for the update process.</param>
    public ExempleUpdateDomainEvent(Guid id,
                                    string firstName,
                                    string lastName,
                                    EGender gender,
                                    ENotificationType notification,
                                    string email,
                                    string phone,
                                    List<string> role,
                                    bool status,
                                    AuthExempleCreateUpdateDeleteModel model)
        : base(id, firstName, lastName, gender, notification, email, phone, role, status, model)
    {
    }
}
