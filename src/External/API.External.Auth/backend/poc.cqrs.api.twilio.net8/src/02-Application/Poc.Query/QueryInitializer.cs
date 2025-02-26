using Microsoft.Extensions.DependencyInjection;

namespace Poc.Query;

public class QueryInitializer
{
    public static void Initialize(IServiceCollection services)
    {
        #region SqlServer
        //services.AddTransient<IRequestHandler<GetUserByIdQuery, Result<UserQueryModel>>, GetUserByIdQueryHandler>();
        //services.AddTransient<IRequestHandler<GetUserQuery, Result<List<UserQueryModel>>>, GetUserQueryHandler>();
        //services.AddTransient<GetUserByIdQueryValidator>();
        #endregion
    }
}
