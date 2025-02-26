using Common.External.Auth.Net8.Enumerado;

namespace API.External.Auth.Domain.User.Events;

/// <summary>
/// Evento que representa uma atualização de um entidade.
/// </summary>
public class UserUpdatedEvent : UserBaseEvent
{
    public UserUpdatedEvent(Guid id, string firstName, string lastName, EGender gender, ENotificationType notification, string email, string phone, string password, List<string> role, DateTime dateOfBirth) :
                       base(id, firstName, lastName, gender, notification, email, phone, password, role, dateOfBirth)
    {
    }
}
