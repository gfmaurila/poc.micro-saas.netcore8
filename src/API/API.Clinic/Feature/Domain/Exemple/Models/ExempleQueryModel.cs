using Common.Core._08.Domain.Enumerado;
using Common.Core._08.Domain.Model;

namespace API.Clinic.Feature.Domain.Exemple.Models;

public class ExempleQueryModel : BaseQueryModel
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public EGender Gender { get; init; }
    public ENotificationType Notification { get; init; }
    public string Email { get; init; }
    public string Phone { get; init; }

    /// <summary>
    /// ERole.cs
    /// RoleConstants.cs
    /// </summary>
    public List<string> Role { get; init; } = new List<string>();
}
