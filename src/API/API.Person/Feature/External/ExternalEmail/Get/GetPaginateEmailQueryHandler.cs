using API.Person.Infrastructure.Integration.ExternalEmail.Service;
using Common.Core._08.Response;
using MediatR;

namespace API.Person.Feature.External.ExternalEmail.Get;

/// <summary>
/// Handles queries for retrieving paginated email records from an external email service.
/// </summary>
public class GetPaginateEmailQueryHandler : IRequestHandler<GetPaginateEmailQuery, ApiResult<GetPaginateEmailQueryResult>>
{
    private readonly IExternalEmailService _emailService;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetPaginateEmailQueryHandler"/> class.
    /// </summary>
    /// <param name="emailService">The external email service responsible for fetching email records.</param>
    public GetPaginateEmailQueryHandler(IExternalEmailService emailService)
    {
        _emailService = emailService;
    }

    /// <summary>
    /// Handles the request to retrieve paginated email records.
    /// </summary>
    /// <param name="request">The request containing pagination parameters.</param>
    /// <param name="cancellationToken">Cancellation token to handle request cancellation.</param>
    /// <returns>An <see cref="ApiResult{T}"/> containing the paginated email records.</returns>
    public async Task<ApiResult<GetPaginateEmailQueryResult>> Handle(GetPaginateEmailQuery request, CancellationToken cancellationToken)
    {
        // Retrieve paginated email records
        var records = await _emailService.GetPaginatedItemsAsync(request);

        // Retrieve the total number of email records
        var totalRecords = await _emailService.GetTotalCountAsync();

        // Calculate the total number of pages
        var totalPages = request.CalculateTotalPages(totalRecords);

        // Create the response object
        var response = new GetPaginateEmailQueryResult(
            total: totalRecords,
            items: records,
            quantidadePaginas: totalPages
        );

        return ApiResult<GetPaginateEmailQueryResult>.CreateSuccess(response, "Email records retrieved successfully.");
    }
}


