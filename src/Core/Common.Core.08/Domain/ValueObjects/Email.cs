namespace Common.Core._08.Domain.ValueObjects;

/// <summary>
/// Represents an email value object, ensuring consistency and immutability.
/// </summary>
public class Email : ValueObject
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Email"/> class with the specified email address.
    /// </summary>
    /// <param name="address">The email address.</param>
    public Email(string address)
        => Address = address.Trim().ToLowerInvariant();

    /// <summary>
    /// Default constructor for ORM use only.
    /// </summary>
    private Email() { }

    /// <summary>
    /// Gets the email address.
    /// </summary>
    public string Address { get; private init; }

    /// <summary>
    /// Returns the email address as a string.
    /// </summary>
    /// <returns>The email address.</returns>
    public override string ToString() => Address;

    /// <summary>
    /// Provides components for equality comparison.
    /// </summary>
    /// <returns>An enumerable containing the email address.</returns>
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Address;
    }
}
