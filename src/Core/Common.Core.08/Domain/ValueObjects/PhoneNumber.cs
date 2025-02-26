namespace Common.Core._08.Domain.ValueObjects;

/// <summary>
/// Represents a phone number as a value object, ensuring consistency and immutability.
/// </summary>
public class PhoneNumber : ValueObject
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PhoneNumber"/> class with the specified phone number.
    /// </summary>
    /// <param name="phone">The phone number.</param>
    public PhoneNumber(string phone)
        => Phone = phone.Trim().ToLowerInvariant();

    /// <summary>
    /// Default constructor for ORM use only.
    /// </summary>
    private PhoneNumber() { }

    /// <summary>
    /// Gets the phone number.
    /// </summary>
    public string Phone { get; private init; }

    /// <summary>
    /// Returns the phone number as a string.
    /// </summary>
    /// <returns>The phone number.</returns>
    public override string ToString() => Phone;

    /// <summary>
    /// Provides components for equality comparison.
    /// </summary>
    /// <returns>An enumerable containing the phone number.</returns>
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Phone;
    }
}

