using API.Person.Infrastructure.Database.Repositories.Interfaces;
using Common.Core._08.Response;
using MediatR;

namespace API.Exemple1.Core._08.Feature.Exemple.Queries.GetPaginate;

/// <summary>
/// Handles the paginated retrieval of Exemple entities based on the provided query parameters.
/// </summary>
public class GetPaginateExempleQueryHandler : IRequestHandler<GetPaginateExempleQuery, ApiResult<GetPaginateExempleQueryResult>>
{
    private readonly IExempleRepository _repo;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetPaginateExempleQueryHandler"/> class.
    /// </summary>
    /// <param name="repo">Repository instance for retrieving paginated Exemple data.</param>
    public GetPaginateExempleQueryHandler(IExempleRepository repo)
    {
        _repo = repo;
    }

    /// <summary>
    /// Handles the request to retrieve paginated Exemple entities.
    /// </summary>
    /// <param name="request">The query containing pagination and filtering parameters.</param>
    /// <param name="cancellationToken">Cancellation token to handle task cancellation.</param>
    /// <returns>An <see cref="ApiResult{T}"/> containing the paginated result.</returns>
    public async Task<ApiResult<GetPaginateExempleQueryResult>> Handle(GetPaginateExempleQuery request, CancellationToken cancellationToken)
    {
        // Retrieve paginated records and total count
        var registros = await _repo.GetPaginatedItemsAsync(request);
        var totalRegistros = await _repo.GetTotalCountAsync(request);

        // Calculate the total number of pages
        var quantidadePaginas = request.CalculateTotalPages(totalRegistros);

        // Create the response object
        var response = new GetPaginateExempleQueryResult(
            total: totalRegistros,
            items: registros,
            filtro: request.FiltroFirstName,
            quantidadePaginas: quantidadePaginas
        );

        return ApiResult<GetPaginateExempleQueryResult>.CreateSuccess(response, "Records successfully retrieved.");
    }
}


