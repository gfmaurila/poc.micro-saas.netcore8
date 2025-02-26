namespace Common.Core._08.Domain.ValueObjects;

/// <summary>
/// Represents a base class for implementing value objects.
/// Provides methods for equality comparison based on the object's components.
/// </summary>
public abstract class ValueObject
{
    /// <summary>
    /// Provides the components that define the equality of the value object.
    /// Derived classes must implement this method to specify the relevant components.
    /// </summary>
    /// <returns>An enumerable of objects that are used to compare equality.</returns>
    protected abstract IEnumerable<object> GetEqualityComponents();

    /// <summary>
    /// Compares two value objects for inequality.
    /// </summary>
    /// <param name="left">The left value object.</param>
    /// <param name="right">The right value object.</param>
    /// <returns>True if the value objects are not equal; otherwise, false.</returns>
    protected static bool NotEqualOperator(ValueObject left, ValueObject right)
    {
        return !EqualOperator(left, right);
    }

    /// <summary>
    /// Compares this value object with another object for equality.
    /// </summary>
    /// <param name="obj">The object to compare with this value object.</param>
    /// <returns>True if the objects are equal; otherwise, false.</returns>
    public override bool Equals(object obj)
    {
        if (obj == null || obj.GetType() != GetType())
            return false;

        return obj is ValueObject other && GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
    }

    /// <summary>
    /// Generates a hash code for the value object based on its equality components.
    /// </summary>
    /// <returns>The hash code of the value object.</returns>
    public override int GetHashCode()
    {
        return GetEqualityComponents()
            .Select(obj => (obj?.GetHashCode()) ?? 0)
            .Aggregate((x, y) => x ^ y);
    }

    /// <summary>
    /// Compares two value objects for equality.
    /// </summary>
    /// <param name="left">The left value object.</param>
    /// <param name="right">The right value object.</param>
    /// <returns>True if the value objects are equal; otherwise, false.</returns>
    private static bool EqualOperator(ValueObject left, ValueObject right)
    {
        if (left is null ^ right is null)
            return false;

        return left?.Equals(right) != false;
    }
}

