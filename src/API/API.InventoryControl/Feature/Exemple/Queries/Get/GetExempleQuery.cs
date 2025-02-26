using API.InventoryControl.Feature.Domain.Exemple.Models;
using Common.Core._08.Response;
using MediatR;

namespace API.Exemple1.Core._08.Feature.Exemple.Queries.Get;

public record GetExempleQuery : IRequest<ApiResult<List<ExempleQueryModel>>>;


