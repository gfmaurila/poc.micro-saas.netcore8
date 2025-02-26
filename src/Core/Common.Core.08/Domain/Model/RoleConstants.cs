using Common.Core._08.Domain.Enumerado;

namespace Common.Core._08.Domain.Model;
/// <summary>
/// Provides constant values representing role identifiers for authorization.
/// </summary>
public static class RoleConstants
{
    // Authorization roles

    /// <summary>
    /// Constant representing the administrator authorization role.
    /// </summary>
    public const string ADMIN_AUTH = nameof(ERole.ADMIN_AUTH);

    /// <summary>
    /// Constant representing the employee authorization role.
    /// </summary>
    public const string EMPLOYEE_AUTH = nameof(ERole.EMPLOYEE_AUTH);

    public const string ADMIN_EXEMPLE = nameof(ERole.ADMIN_EXEMPLE);
    public const string EMPLOYEE_EXEMPLE = nameof(ERole.EMPLOYEE_EXEMPLE);
}
