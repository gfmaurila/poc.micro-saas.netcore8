using Ardalis.SmartEnum;

namespace Common.Core._08.Domain.Errors;

/// <summary>
/// Represents a base class for defining error types using the SmartEnum pattern.
/// </summary>
public abstract class ErrorType(string name, int value) : SmartEnum<ErrorType>(name, value)
{
    /// <summary>
    /// Represents a conflict error.
    /// </summary>
    public static readonly ErrorType Conflict = new ConflictEnum();

    /// <summary>
    /// Represents a not found error.
    /// </summary>
    public static readonly ErrorType NotFound = new NotFoundEnum();

    /// <summary>
    /// Represents a bad request error.
    /// </summary>
    public static readonly ErrorType BadRequest = new BadRequestEnum();

    /// <summary>
    /// Represents a validation error.
    /// </summary>
    public static readonly ErrorType Validation = new ValidationEnum();

    /// <summary>
    /// Represents an unexpected error.
    /// </summary>
    public static readonly ErrorType Unexpected = new UnexpectedEnum();

    // Define each specific ErrorType as a nested class that extends SmartEnum

    /// <summary>
    /// Represents a conflict error type.
    /// </summary>
    private class ConflictEnum : ErrorType
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConflictEnum"/> class with the name "Conflict" and value 0.
        /// </summary>
        public ConflictEnum() : base("Conflict", 0) { }
    }

    /// <summary>
    /// Represents a not found error type.
    /// </summary>
    private class NotFoundEnum : ErrorType
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundEnum"/> class with the name "NotFound" and value 1.
        /// </summary>
        public NotFoundEnum() : base("NotFound", 1) { }
    }

    /// <summary>
    /// Represents a bad request error type.
    /// </summary>
    private class BadRequestEnum : ErrorType
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BadRequestEnum"/> class with the name "BadRequest" and value 2.
        /// </summary>
        public BadRequestEnum() : base("BadRequest", 2) { }
    }

    /// <summary>
    /// Represents a validation error type.
    /// </summary>
    private class ValidationEnum : ErrorType
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationEnum"/> class with the name "Validation" and value 3.
        /// </summary>
        public ValidationEnum() : base("Validation", 3) { }
    }

    /// <summary>
    /// Represents an unexpected error type.
    /// </summary>
    private class UnexpectedEnum : ErrorType
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnexpectedEnum"/> class with the name "Unexpected" and value 4.
        /// </summary>
        public UnexpectedEnum() : base("Unexpected", 4) { }
    }
}

