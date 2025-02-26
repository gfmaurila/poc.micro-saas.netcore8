using Common.Core._08.Domain.Enumerado;

namespace API.Exemple.Core._08.Tests.Integration.Features.Fakes;

public static class UtilFake
{
    public static List<string> Role()
    {
        return new List<string>
                    {
                        ERole.ADMIN_AUTH.ToString(),
                        ERole.EMPLOYEE_AUTH.ToString(),
                        ERole.EMPLOYEE_EXEMPLE.ToString(),
                        ERole.EMPLOYEE_EXEMPLE.ToString(),
                    };
    }
}
