using Common.Core._08.Response;
using MediatR;

namespace API.Exemple1.Core._08.Feature.Exemple.Commands.Delete;

public record DeleteExempleCommand(Guid Id) : IRequest<ApiResult<DeleteExempleResponse>>;


