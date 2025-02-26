using Common.Core._08.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Common.Core._08.Request;

/// <summary>
/// Represents a paginated request for a query, containing pagination parameters and utility methods.
/// </summary>
/// <typeparam name="TQueryResponse">The type of the query response.</typeparam>
/// <typeparam name="TQueryResponseItem">The type of the items in the query response.</typeparam>
public abstract class QueryRequestPaged<TQueryResponse, TQueryResponseItem> : IRequest<ApiResult<TQueryResponse>>
    where TQueryResponse : QueryResponsePaged<TQueryResponseItem>
    where TQueryResponseItem : class, new()
{
    /// <summary>
    /// Initializes a new instance of the <see cref="QueryRequestPaged{TQueryResponse, TQueryResponseItem}"/> class
    /// with default values for pagination parameters.
    /// </summary>
    /// <param name="defaultPageSize">The default number of records per page (default: 10).</param>
    /// <param name="defaultPageNumber">The default page number (default: 1).</param>
    protected QueryRequestPaged(int defaultPageSize = 10, int defaultPageNumber = 1)
    {
        PageNumber = defaultPageNumber;
        PageSize = defaultPageSize;
    }

    /// <summary>
    /// Gets or sets the current page number.
    /// </summary>
    [FromQuery]
    public int PageNumber { get; set; }

    /// <summary>
    /// Gets or sets the number of records per page.
    /// </summary>
    [FromQuery]
    public int PageSize { get; set; }

    /// <summary>
    /// Calculates the number of records to skip based on the current page and page size.
    /// </summary>
    /// <returns>The number of records to skip.</returns>
    public int CalculateRecordsToSkip()
    {
        return (PageNumber - 1) * PageSize;
    }

    /// <summary>
    /// Calculates the total number of pages based on the total number of records and the page size.
    /// </summary>
    /// <param name="totalRecords">The total number of records.</param>
    /// <returns>The total number of pages.</returns>
    public int CalculateTotalPages(int totalRecords)
    {
        return (int)Math.Ceiling((double)totalRecords / PageSize);
    }
}



