using Common.External.Auth.Net8.User;

namespace API.External.Auth.Tests.Integration.Features.Fakes;

public static class UtilFake
{
    public static List<string> Role()
    {
        return new List<string>
                    {
                        ERoleUserAuth.ADMIN_AUTH.ToString(),
                        ERoleUserAuth.EMPLOYEE_AUTH.ToString(),
                    };
    }
}
