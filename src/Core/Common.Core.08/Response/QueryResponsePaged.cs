namespace Common.Core._08.Response;

/// <summary>
/// Represents a paginated response for a query, containing the total number of records and the returned items.
/// </summary>
/// <typeparam name="TQueryResponseItem">The type of items returned in the response.</typeparam>
public abstract class QueryResponsePaged<TQueryResponseItem>
    where TQueryResponseItem : class, new()
{
    /// <summary>
    /// Default constructor that initializes an empty list of items.
    /// </summary>
    protected QueryResponsePaged()
    {
        Items = new List<TQueryResponseItem>();
    }

    /// <summary>
    /// Constructor that initializes the response with the total number of records and the provided items.
    /// </summary>
    /// <param name="total">The total number of available records.</param>
    /// <param name="items">The list of items returned in the current page.</param>
    protected QueryResponsePaged(int total, List<TQueryResponseItem> items)
    {
        Total = total;
        Items = items;
    }

    /// <summary>
    /// Gets or sets the total number of available records for the query.
    /// </summary>
    public int Total { get; set; }

    /// <summary>
    /// Gets or sets the list of items returned in the current page of the query.
    /// </summary>
    public List<TQueryResponseItem> Items { get; set; }
}


