using Microsoft.AspNetCore.Http;

namespace Common.Core._08.Response;

/// <summary>
/// Class responsible for standardizing API responses.
/// </summary>
public class ApiResponse
{
    #region Properties

    /// <summary>
    /// Indicates whether the request was successful.
    /// </summary>
    public bool Success { get; set; }

    /// <summary>
    /// Success message.
    /// </summary>
    public string SuccessMessage { get; set; }

    /// <summary>
    /// The HTTP status code of the response.
    /// </summary>
    public int StatusCode { get; set; }

    /// <summary>
    /// A list of errors if the request was not successful.
    /// </summary>
    public IEnumerable<ApiError> Errors { get; set; } = Enumerable.Empty<ApiError>();

    #endregion

    #region HTTP Status 200 OK

    /// <summary>
    /// Creates a response with HTTP status 200.
    /// </summary>
    public static ApiResponse Ok()
        => new() { Success = true, StatusCode = StatusCodes.Status200OK };

    /// <summary>
    /// Creates a response with HTTP status 200 and a success message.
    /// </summary>
    /// <param name="successMessage">The success message to include in the response.</param>
    public static ApiResponse Ok(string successMessage)
        => new() { Success = true, StatusCode = StatusCodes.Status200OK, SuccessMessage = successMessage };

    #endregion

    #region HTTP Status 400 Bad Request

    /// <summary>
    /// Creates a response with HTTP status 400.
    /// </summary>
    public static ApiResponse BadRequest()
        => new() { Success = false, StatusCode = StatusCodes.Status400BadRequest };

    /// <summary>
    /// Creates a response with HTTP status 400 and an error message.
    /// </summary>
    /// <param name="errorMessage">The error message to include in the response.</param>
    public static ApiResponse BadRequest(string errorMessage)
        => new() { Success = false, StatusCode = StatusCodes.Status400BadRequest, Errors = CreateApiErrors(errorMessage) };

    /// <summary>
    /// Creates a response with HTTP status 400 and a list of errors.
    /// </summary>
    /// <param name="errors">The list of errors to include in the response.</param>
    public static ApiResponse BadRequest(IEnumerable<ApiError> errors)
        => new() { Success = false, StatusCode = StatusCodes.Status400BadRequest, Errors = errors };

    #endregion

    #region HTTP Status 401 Unauthorized

    /// <summary>
    /// Creates a response with HTTP status 401.
    /// </summary>
    public static ApiResponse Unauthorized()
        => new() { Success = false, StatusCode = StatusCodes.Status401Unauthorized };

    /// <summary>
    /// Creates a response with HTTP status 401 and an error message.
    /// </summary>
    /// <param name="errorMessage">The error message to include in the response.</param>
    public static ApiResponse Unauthorized(string errorMessage)
        => new() { Success = false, StatusCode = StatusCodes.Status401Unauthorized, Errors = CreateApiErrors(errorMessage) };

    /// <summary>
    /// Creates a response with HTTP status 401 and a list of errors.
    /// </summary>
    /// <param name="errors">The list of errors to include in the response.</param>
    public static ApiResponse Unauthorized(IEnumerable<ApiError> errors)
        => new() { Success = false, StatusCode = StatusCodes.Status401Unauthorized, Errors = errors };

    #endregion

    #region HTTP Status 403 Forbidden

    /// <summary>
    /// Creates a response with HTTP status 403.
    /// </summary>
    public static ApiResponse Forbidden()
        => new() { Success = false, StatusCode = StatusCodes.Status403Forbidden };

    /// <summary>
    /// Creates a response with HTTP status 403 and an error message.
    /// </summary>
    /// <param name="errorMessage">The error message to include in the response.</param>
    public static ApiResponse Forbidden(string errorMessage)
        => new() { Success = false, StatusCode = StatusCodes.Status403Forbidden, Errors = CreateApiErrors(errorMessage) };

    /// <summary>
    /// Creates a response with HTTP status 403 and a list of errors.
    /// </summary>
    /// <param name="errors">The list of errors to include in the response.</param>
    public static ApiResponse Forbidden(IEnumerable<ApiError> errors)
        => new() { Success = false, StatusCode = StatusCodes.Status403Forbidden, Errors = errors };

    #endregion

    #region HTTP Status 404 Not Found

    /// <summary>
    /// Creates a response with HTTP status 404.
    /// </summary>
    public static ApiResponse NotFound()
        => new() { Success = false, StatusCode = StatusCodes.Status404NotFound };

    /// <summary>
    /// Creates a response with HTTP status 404 and an error message.
    /// </summary>
    /// <param name="errorMessage">The error message to include in the response.</param>
    public static ApiResponse NotFound(string errorMessage)
        => new() { Success = false, StatusCode = StatusCodes.Status404NotFound, Errors = CreateApiErrors(errorMessage) };

    /// <summary>
    /// Creates a response with HTTP status 404 and a list of errors.
    /// </summary>
    /// <param name="errors">The list of errors to include in the response.</param>
    public static ApiResponse NotFound(IEnumerable<ApiError> errors)
        => new() { Success = false, StatusCode = StatusCodes.Status404NotFound, Errors = errors };

    #endregion

    #region HTTP Status 500 Internal Server Error

    /// <summary>
    /// Creates a response with HTTP status 500 and an error message.
    /// </summary>
    /// <param name="errorMessage">The error message to include in the response.</param>
    public static ApiResponse InternalServerError(string errorMessage)
        => new() { Success = false, StatusCode = StatusCodes.Status500InternalServerError, Errors = CreateApiErrors(errorMessage) };

    /// <summary>
    /// Creates a response with HTTP status 500 and a list of errors.
    /// </summary>
    /// <param name="errors">The list of errors to include in the response.</param>
    public static ApiResponse InternalServerError(IEnumerable<ApiError> errors)
        => new() { Success = false, StatusCode = StatusCodes.Status500InternalServerError, Errors = errors };

    #endregion

    private static IEnumerable<ApiError> CreateApiErrors(string errorMessage)
        => new[] { new ApiError(errorMessage) };
}

/// <summary>
/// Represents a generic API response with a result.
/// </summary>
/// <typeparam name="T">The type of the result.</typeparam>
public sealed class ApiResponse<T> : ApiResponse
{
    /// <summary>
    /// Gets the result of the response.
    /// </summary>
    public T Result { get; private init; }

    /// <summary>
    /// Creates a response with HTTP status 200 and a result.
    /// </summary>
    /// <param name="result">The result to include in the response.</param>
    public static ApiResponse<T> Ok(T result)
        => new() { Success = true, StatusCode = StatusCodes.Status200OK, Result = result };

    /// <summary>
    /// Creates a response with HTTP status 200, a result, and a success message.
    /// </summary>
    /// <param name="result">The result to include in the response.</param>
    /// <param name="successMessage">The success message to include in the response.</param>
    public static ApiResponse<T> Ok(T result, string successMessage)
        => new() { Success = true, StatusCode = StatusCodes.Status200OK, Result = result, SuccessMessage = successMessage };
}
