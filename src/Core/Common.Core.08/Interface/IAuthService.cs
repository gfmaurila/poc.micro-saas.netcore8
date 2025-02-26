namespace Common.Core._08.Interface;

/// <summary>
/// Defines methods for generating JSON Web Tokens (JWT) for authentication and authorization.
/// </summary>
public interface IAuthService
{
    /// <summary>
    /// Generates a JSON Web Token (JWT) for a user with the specified ID, email, and roles.
    /// </summary>
    /// <param name="id">The user's unique identifier.</param>
    /// <param name="email">The user's email address.</param>
    /// <param name="role">A list of roles associated with the user.</param>
    /// <returns>A JWT as a string.</returns>
    string GenerateJwtToken(string id, string email, List<string> role);

    /// <summary>
    /// Generates a JSON Web Token (JWT) for a user with the specified ID and email.
    /// </summary>
    /// <param name="id">The user's unique identifier.</param>
    /// <param name="email">The user's email address.</param>
    /// <returns>A JWT as a string.</returns>
    string GenerateJwtToken(string id, string email);
}

