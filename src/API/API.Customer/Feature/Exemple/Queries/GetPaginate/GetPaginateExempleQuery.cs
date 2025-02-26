using API.Customer.Feature.Domain.Exemple.Models;
using Common.Core._08.Request;
using Microsoft.AspNetCore.Mvc;

namespace API.Exemple1.Core._08.Feature.Exemple.Queries.GetPaginate;

/// <summary>
/// Represents a paginated query request for retrieving Exemple entities.
/// Allows filtering by the first name.
/// </summary>
public class GetPaginateExempleQuery : QueryRequestPaged<GetPaginateExempleQueryResult, ExempleQueryModel>
{
    /// <summary>
    /// Gets or sets an optional filter for Exemple entities based on the first name.
    /// </summary>
    [FromQuery]
    public string? FiltroFirstName { get; set; }
}