namespace Common.Core._08.Response;

/// <summary>
/// Represents an error response in the API, containing an error message.
/// </summary>
/// <param name="Message">The message describing the error.</param>
public sealed record ApiError(string Message);

