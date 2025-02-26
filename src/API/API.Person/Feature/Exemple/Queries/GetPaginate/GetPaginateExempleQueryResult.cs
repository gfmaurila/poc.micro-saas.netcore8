using API.Person.Feature.Domain.Exemple.Models;
using Common.Core._08.Response;

namespace API.Exemple1.Core._08.Feature.Exemple.Queries.GetPaginate;

/// <summary>
/// Represents the paginated query result for retrieving Exemple entities.
/// Contains metadata about the total records, applied filters, and pagination details.
/// </summary>
public class GetPaginateExempleQueryResult : QueryResponsePaged<ExempleQueryModel>
{
    /// <summary>
    /// Gets or sets the applied filter for the query.
    /// </summary>
    public string? Filtro { get; set; }

    /// <summary>
    /// Gets or sets the total number of pages in the paginated result.
    /// </summary>
    public int QuantidadePaginas { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="GetPaginateExempleQueryResult"/> class.
    /// </summary>
    /// <param name="total">The total number of records available.</param>
    /// <param name="items">The list of paginated <see cref="ExempleQueryModel"/> results.</param>
    /// <param name="filtro">The applied filter criteria, if any.</param>
    /// <param name="quantidadePaginas">The total number of pages based on the current page size.</param>
    public GetPaginateExempleQueryResult(int total, List<ExempleQueryModel> items, string? filtro, int quantidadePaginas)
        : base(total, items)
    {
        Filtro = filtro;
        QuantidadePaginas = quantidadePaginas;
    }
}