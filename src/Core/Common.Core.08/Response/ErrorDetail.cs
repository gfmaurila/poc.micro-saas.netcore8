namespace Common.Core._08.Response;

/// <summary>
/// Represents detailed information about an error in an API response.
/// </summary>
public class ErrorDetail
{
    /// <summary>
    /// Gets or sets the message describing the error.
    /// </summary>
    public string Message { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ErrorDetail"/> class with the specified error message.
    /// </summary>
    /// <param name="message">The message describing the error.</param>
    public ErrorDetail(string message)
    {
        Message = message;
    }
}

