using Common.Core._08.Domain.Enumerado;
using Common.Core._08.Response;
using MediatR;

namespace API.Exemple1.Core._08.Feature.Exemple.Commands.Create;

public record CreateExempleCommand(
    string FirstName,
    string LastName,
    bool Status,
    EGender Gender,
    ENotificationType Notification,
    string Email,
    string Phone,
    List<string> Role
) : IRequest<ApiResult<CreateExempleResponse>>;

