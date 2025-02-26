using Common.Core._08.Domain.Enumerado;
using Common.Core._08.Response;
using MediatR;

namespace API.Exemple1.Core._08.Feature.Exemple.Commands.Update;

public record UpdateExempleCommand(
    Guid Id,
    string FirstName,
    string LastName,
    bool Status,
    EGender Gender,
    ENotificationType Notification,
    string Email,
    string Phone,
    List<string> Role
) : IRequest<ApiResult<UpdateExempleResponse>>;


