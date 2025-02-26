using Common.External.Auth.Net8.Enumerado;
using Common.External.Auth.Net8.Events;

namespace API.External.Auth.Domain.User.Events;


public abstract class UserBaseEvent : Event
{
    protected UserBaseEvent(Guid id, string firstName, string lastName, EGender gender, ENotificationType notification, string email, string phone, string password, List<string> role, DateTime dateOfBirth)
    {
        Id = id;
        AggregateId = id;
        FirstName = firstName;
        LastName = lastName;
        Gender = gender;
        Notification = notification;
        Email = email;
        Phone = phone;
        RoleUserAuth = role;
        Password = password;
        DateOfBirth = dateOfBirth;
    }

    public Guid Id { get; private init; }
    public string FirstName { get; private init; }

    public string LastName { get; private init; }

    public EGender Gender { get; private init; }
    public ENotificationType Notification { get; private init; }

    public DateTime DateOfBirth { get; private init; }

    public string Email { get; private set; }
    public string Phone { get; private set; }

    public string Password { get; private set; }

    public List<string> RoleUserAuth { get; private set; } = new List<string>();
}