namespace Common.Core._08.Response;

/// <summary>
/// Represents a standardized API response that includes the status, messages, errors, and data.
/// </summary>
/// <typeparam name="T">The type of the data included in the response.</typeparam>
public class ApiResult<T>
{
    /// <summary>
    /// Indicates whether the request was successful.
    /// </summary>
    public bool Success { get; set; }

    /// <summary>
    /// A success message associated with the response.
    /// </summary>
    public string SuccessMessage { get; set; }

    /// <summary>
    /// The HTTP status code of the response.
    /// </summary>
    public int StatusCode { get; set; }

    /// <summary>
    /// A list of detailed errors if the request failed.
    /// </summary>
    public List<ErrorDetail> Errors { get; set; }

    /// <summary>
    /// The data returned by the request, if any.
    /// </summary>
    public T Data { get; set; }

    /// <summary>
    /// Creates an error response with a list of errors and a specified HTTP status code.
    /// </summary>
    /// <param name="errors">A list of errors to include in the response.</param>
    /// <param name="statusCode">The HTTP status code to assign to the response.</param>
    /// <returns>An instance of <see cref="ApiResult{T}"/> representing the error response.</returns>
    public static ApiResult<T> CreateError(List<ErrorDetail> errors, int statusCode)
    {
        return new ApiResult<T>
        {
            Success = false,
            StatusCode = statusCode,
            Errors = errors
        };
    }

    /// <summary>
    /// Creates a success response with the provided data and a default success message.
    /// </summary>
    /// <param name="result">The data to include in the response.</param>
    /// <returns>An instance of <see cref="ApiResult{T}"/> representing the success response.</returns>
    public static ApiResult<T> CreateSuccess(T result)
    {
        return new ApiResult<T>
        {
            Success = true,
            SuccessMessage = "Created successfully!",
            StatusCode = 200,
            Errors = new List<ErrorDetail>()
        };
    }

    /// <summary>
    /// Creates a success response with the provided data and a custom success message.
    /// </summary>
    /// <param name="value">The data to include in the response.</param>
    /// <param name="successMessage">The success message to include in the response.</param>
    /// <returns>An instance of <see cref="ApiResult{T}"/> representing the success response.</returns>
    public static ApiResult<T> CreateSuccess(T value, string successMessage)
    {
        return new ApiResult<T>
        {
            Success = true,
            SuccessMessage = successMessage,
            StatusCode = 200,
            Errors = new List<ErrorDetail>(),
            Data = value
        };
    }
}

