using API.Customer.Feature.Domain.Exemple.Events;
using API.Customer.Feature.Domain.Exemple.Models;
using API.Exemple1.Core._08.Feature.Domain.Exemple.Events.Messaging;
using API.Exemple1.Core._08.Feature.Exemple.Commands.Create;
using API.Exemple1.Core._08.Feature.Exemple.Commands.Update;
using Common.Core._08.Domain;
using Common.Core._08.Domain.Enumerado;
using Common.Core._08.Domain.Interface;
using Common.Core._08.Domain.ValueObjects;

namespace API.Customer.Feature.Domain.Exemple;

/// <summary>
/// Represents an example entity that follows the aggregate root pattern.
/// </summary>
public class ExempleEntity : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// Gets the first name of the entity.
    /// </summary>
    public string FirstName { get; private set; }

    /// <summary>
    /// Gets the last name of the entity.
    /// </summary>
    public string LastName { get; private set; }

    /// <summary>
    /// Gets the gender of the entity.
    /// </summary>
    public EGender Gender { get; private set; }

    /// <summary>
    /// Gets the preferred notification type for the entity.
    /// </summary>
    public ENotificationType Notification { get; private set; }

    /// <summary>
    /// Gets the email of the entity.
    /// </summary>
    public Email Email { get; private set; }

    /// <summary>
    /// Gets the phone number of the entity.
    /// </summary>
    public PhoneNumber Phone { get; private set; }

    /// <summary>
    /// Gets the roles assigned to the entity.
    /// </summary>
    public List<string> Role { get; private set; } = new List<string>();

    /// <summary>
    /// Default constructor required for ORM.
    /// </summary>
    public ExempleEntity() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ExempleEntity"/> class.
    /// </summary>
    /// <param name="request">The command containing data to create an example entity.</param>
    /// <param name="model">The authentication model for tracking insert operations.</param>
    public ExempleEntity(CreateExempleCommand request, AuthExempleCreateUpdateDeleteModel model)
    {
        var email = new Email(request.Email);
        var phone = new PhoneNumber(request.Phone);

        FirstName = request.FirstName;
        LastName = request.LastName;
        Gender = request.Gender;
        Notification = request.Notification;
        Email = email;
        Phone = phone;
        Role = request.Role;
        Status = request.Status;

        DtInsert = model.DtInsert;
        DtInsertId = model.DtInsertId;

        // Adds domain event for entity creation
        AddDomainEvent(new ExempleCreateDomainEvent(Id, request, model));

        // Adds event for sending email/WhatsApp via RabbitMQ
        AddDomainEvent(new ExempleCreateEvent(Id, request, model));
    }

    /// <summary>
    /// Updates the entity with new data.
    /// </summary>
    /// <param name="command">The command containing updated entity data.</param>
    /// <param name="model">The authentication model for tracking update operations.</param>
    public void Update(UpdateExempleCommand command, AuthExempleCreateUpdateDeleteModel model)
    {
        FirstName = command.FirstName;
        LastName = command.LastName;
        Gender = command.Gender;
        Notification = command.Notification;
        Email = new Email(command.Email);
        Phone = new PhoneNumber(command.Phone);
        Role = command.Role;
        DtUpdate = model.DtUpdate;
        DtUpdateId = model.DtUpdateId;
        Status = command.Status;

        // Adds domain event for entity update
        AddDomainEvent(new ExempleUpdateDomainEvent(
            Id,
            command.FirstName,
            command.LastName,
            command.Gender,
            command.Notification,
            command.Email,
            command.Phone,
            command.Role,
            command.Status,
            model));

        // Adds event for sending email/WhatsApp via RabbitMQ
        AddDomainEvent(new ExempleUpdateEvent(Id, command, model));
    }

    /// <summary>
    /// Marks the entity as deleted and triggers associated events.
    /// </summary>
    public void Delete()
    {
        // Adds domain event for entity deletion
        AddDomainEvent(new ExempleDeleteDomainEvent(
            Id, FirstName, LastName, Gender, Notification, Email.Address, Phone.Phone, Role));

        // Adds event for sending email/WhatsApp via RabbitMQ
        AddDomainEvent(new ExempleDeleteEvent(
            Id, FirstName, LastName, Gender, Notification, Email.Address, Phone.Phone, Role));
    }
}

