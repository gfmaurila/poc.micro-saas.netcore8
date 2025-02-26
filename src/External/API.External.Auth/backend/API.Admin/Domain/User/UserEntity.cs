using API.External.Auth.Domain.User.Events;
using API.External.Auth.Domain.User.Events.Auth;
using API.External.Auth.Feature.Users.UpdateUser;
using Common.External.Auth.Net8;
using Common.External.Auth.Net8.Abstractions;
using Common.External.Auth.Net8.Enumerado;
using Common.External.Auth.Net8.ValueObjects;

namespace API.External.Auth.Domain.User;

public class UserEntity : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// Inicializa uma inståncia de um novo usuario.
    /// </summary>
    /// <param name="firstName"></param>
    /// <param name="lastName"></param>
    /// <param name="gender"></param>
    /// <param name="notification"></param>
    /// <param name="email"></param>
    /// <param name="phone"></param>
    /// <param name="password"></param>
    /// <param name="role"></param>
    /// <param name="dateOfBirth"></param>
    public UserEntity(string firstName, string lastName, EGender gender, ENotificationType notification, Email email, PhoneNumber phone, string password, List<string> role, DateTime dateOfBirth)
    {
        FirstName = firstName;
        LastName = lastName;
        Gender = gender;
        Notification = notification;
        Email = email;
        Phone = phone;
        RoleUserAuth = role;
        Password = password;
        DateOfBirth = dateOfBirth;

        // Adicionando a nova instãncia nos eventos de domínio.
        AddDomainEvent(new UserCreatedEvent(Id, firstName, lastName, gender, notification, email.Address, phone.Phone, password, role, dateOfBirth));
    }

    public UserEntity() { } // ORM

    /// <summary>
    /// Primeiro Nome.
    /// </summary>
    public string FirstName { get; private set; }

    /// <summary>
    /// Sobrenome.
    /// </summary>
    public string LastName { get; private set; }

    /// <summary>
    /// Gênero.
    /// </summary>
    public EGender Gender { get; private set; }

    /// <summary>
    /// Valida se as notificações vão chegar por e-mail, sms ou whatsapp
    /// </summary>
    public ENotificationType Notification { get; private set; }

    /// <summary>
    /// Data de Nascimento.
    /// </summary>
    public DateTime DateOfBirth { get; private set; }

    /// <summary>
    /// Endereço de e-mail.
    /// </summary>
    public Email Email { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public PhoneNumber Phone { get; private set; }

    /// <summary>
    /// Senha de acesso
    /// </summary>
    public string Password { get; private set; }

    /// <summary>
    /// Roles do sistema
    /// </summary>
    public List<string> RoleUserAuth { get; private set; } = new List<string>();


    public void ChangeEmail(Email newEmail)
    {
        if (!Email.Equals(newEmail))
        {
            Email = newEmail;
            AddDomainEvent(new UserUpdatedEvent(Id, FirstName, LastName, Gender, Notification, newEmail.Address, Phone.Phone, Password, RoleUserAuth, DateOfBirth));
        }
    }

    /// <summary>
    /// Altera registros
    /// </summary>
    /// <param name="dto"></param>
    public void Update(UpdateUserCommand dto)
    {
        FirstName = dto.FirstName;
        LastName = dto.LastName;
        Phone = new PhoneNumber(dto.Phone);
        Gender = dto.Gender;
        Notification = dto.Notification;
        DateOfBirth = dto.DateOfBirth;
        AddDomainEvent(new UserUpdatedEvent(Id, dto.FirstName, dto.LastName, dto.Gender, dto.Notification, Email.Address, dto.Phone, Password, RoleUserAuth, dto.DateOfBirth));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="role"></param>
    public void UpdateRole(List<string> role)
    {
        RoleUserAuth = role;
        AddDomainEvent(new UserUpdatedEvent(Id, FirstName, LastName, Gender, Notification, Email.Address, Phone.Phone, Password, role, DateOfBirth));
    }

    /// <summary>
    /// Altera o Senha.
    /// </summary>
    /// <param name="password"></param>
    public void ChangePassword(string password)
    {
        // Só será alterado o e-mail se for diferente do existente.
        if (!Password.Equals(password))
        {
            Password = password;
            // Adicionando a alteração nos eventos de domínio.
            AddDomainEvent(new UserUpdatedEvent(Id, FirstName, LastName, Gender, Notification, Email.Address, Phone.Phone, Password, RoleUserAuth, DateOfBirth));
        }
    }

    /// <summary>
    /// Adiciona o evento de entidade deletada.
    /// </summary>
    public void Delete()
        => AddDomainEvent(new UserDeletedEvent(Id, FirstName, LastName, Gender, Notification, Email.Address, Phone.Phone, Password, RoleUserAuth, DateOfBirth));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="lastName"></param>
    /// <param name="email"></param>
    /// <param name="token"></param>
    public void AuthEvent(string id, string lastName, string email, string token)
        => AddDomainEvent(new AuthEvent(id, lastName, email, token, DateTime.Now.AddHours(8)));

    /// <summary>
    /// 
    /// </summary>
    public void AuthResetEvent()
        => AddDomainEvent(new AuthResetEvent(Id, FirstName, LastName, Gender, Notification, Email.Address, Phone.Phone, Password, RoleUserAuth, DateOfBirth));

}