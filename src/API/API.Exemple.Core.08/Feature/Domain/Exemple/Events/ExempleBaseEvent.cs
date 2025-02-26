using API.Exemple.Core._08.Feature.Domain.Exemple.Models;
using Common.Core._08.Domain.Enumerado;
using Common.Core._08.Domain.Events;

namespace API.Exemple.Core._08.Feature.Domain.Exemple.Events;

/// <summary>
/// Represents the base event class for Exemple-related events.
/// </summary>
public abstract class ExempleBaseEvent : Event
{
    /// <summary>
    /// Gets the unique identifier of the Exemple entity.
    /// </summary>
    public Guid Id { get; private init; }

    /// <summary>
    /// Gets the first name of the Exemple entity.
    /// </summary>
    public string FirstName { get; private init; }

    /// <summary>
    /// Gets the last name of the Exemple entity.
    /// </summary>
    public string LastName { get; private init; }

    /// <summary>
    /// Gets the gender of the Exemple entity.
    /// </summary>
    public EGender Gender { get; private init; }

    /// <summary>
    /// Gets the notification type associated with the Exemple entity.
    /// </summary>
    public ENotificationType Notification { get; private init; }

    /// <summary>
    /// Gets the email address of the Exemple entity.
    /// </summary>
    public string Email { get; private init; }

    /// <summary>
    /// Gets the phone number of the Exemple entity.
    /// </summary>
    public string Phone { get; private init; }

    /// <summary>
    /// Gets the list of roles associated with the Exemple entity.
    /// </summary>
    public List<string> Role { get; private init; } = new List<string>();

    /// <summary>
    /// Gets the status of the Exemple entity (active/inactive).
    /// </summary>
    public bool Status { get; private init; } = true;

    /// <summary>
    /// Gets the insertion date and time of the Exemple entity.
    /// </summary>
    public DateTime? DtInsert { get; private init; } = DateTime.UtcNow;

    /// <summary>
    /// Gets the ID of the user who inserted the Exemple entity.
    /// </summary>
    public int? DtInsertId { get; private init; }

    /// <summary>
    /// Gets the update date and time of the Exemple entity.
    /// </summary>
    public DateTime? DtUpdate { get; private init; }

    /// <summary>
    /// Gets the ID of the user who updated the Exemple entity.
    /// </summary>
    public int? DtUpdateId { get; private init; }

    /// <summary>
    /// Gets the deletion date and time of the Exemple entity.
    /// </summary>
    public DateTime? DtDelete { get; private init; }

    /// <summary>
    /// Gets the ID of the user who deleted the Exemple entity.
    /// </summary>
    public int? DtDeleteId { get; private init; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ExempleBaseEvent"/> class.
    /// </summary>
    /// <param name="id">The unique identifier of the Exemple entity.</param>
    /// <param name="firstName">The first name of the Exemple entity.</param>
    /// <param name="lastName">The last name of the Exemple entity.</param>
    /// <param name="gender">The gender of the Exemple entity.</param>
    /// <param name="notification">The notification type associated with the Exemple entity.</param>
    /// <param name="email">The email address of the Exemple entity.</param>
    /// <param name="phone">The phone number of the Exemple entity.</param>
    /// <param name="role">The list of roles associated with the Exemple entity.</param>
    public ExempleBaseEvent(Guid id, string firstName, string lastName, EGender gender, ENotificationType notification, string email, string phone, List<string> role)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Gender = gender;
        Notification = notification;
        Email = email;
        Phone = phone;
        Role = role;
        AggregateId = Guid.NewGuid();
        MessageType = nameof(ExempleBaseEvent);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ExempleBaseEvent"/> class, including status and audit information.
    /// </summary>
    /// <param name="id">The unique identifier of the Exemple entity.</param>
    /// <param name="firstName">The first name of the Exemple entity.</param>
    /// <param name="lastName">The last name of the Exemple entity.</param>
    /// <param name="gender">The gender of the Exemple entity.</param>
    /// <param name="notification">The notification type associated with the Exemple entity.</param>
    /// <param name="email">The email address of the Exemple entity.</param>
    /// <param name="phone">The phone number of the Exemple entity.</param>
    /// <param name="role">The list of roles associated with the Exemple entity.</param>
    /// <param name="status">The active/inactive status of the Exemple entity.</param>
    /// <param name="model">The model containing audit information.</param>
    public ExempleBaseEvent(Guid id,
                            string firstName,
                            string lastName,
                            EGender gender,
                            ENotificationType notification,
                            string email,
                            string phone,
                            List<string> role,
                            bool status,
                            AuthExempleCreateUpdateDeleteModel model)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Gender = gender;
        Notification = notification;
        Email = email;
        Phone = phone;
        Role = role;
        Status = status;

        DtInsertId = model.DtInsertId;
        DtInsert = model.DtInsert;
        DtUpdateId = model.DtUpdateId;
        DtUpdate = model.DtUpdate;
        DtDeleteId = model.DtDeleteId;
        DtDelete = model.DtDelete;

        AggregateId = Guid.NewGuid();
        MessageType = nameof(ExempleBaseEvent);
    }
}
