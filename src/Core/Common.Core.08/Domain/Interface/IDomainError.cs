using Common.Core._08.Domain.Errors;

namespace Common.Core._08.Domain.Interface;

/// <summary>
/// Represents a domain error, including its type, message, and additional error details.
/// </summary>
public interface IDomainError
{
    /// <summary>
    /// Gets the error message that describes the domain error.
    /// </summary>
    string? ErrorMessage { get; init; }

    /// <summary>
    /// Gets the type of the domain error.
    /// </summary>
    ErrorType ErrorType { get; init; }

    /// <summary>
    /// Gets a list of additional error details, if any.
    /// </summary>
    List<string>? Errors { get; init; }
}

