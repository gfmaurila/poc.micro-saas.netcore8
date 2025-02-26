using Common.Core._08.Handle;
using Common.Core._08.Interface;
using Common.Core._08.Service;

namespace API.Exemple.Core._08.Infrastructure.Auth;

public class CoreInitializer
{
    public static void Initialize(IServiceCollection services)
    {
        services.AddTransient<INotificationHandle, NotificationHandle>();
        services.AddTransient<IAuthService, AuthService>();
    }
}
