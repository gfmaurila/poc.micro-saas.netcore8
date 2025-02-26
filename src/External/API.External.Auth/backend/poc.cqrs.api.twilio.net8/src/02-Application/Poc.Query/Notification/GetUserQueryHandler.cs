//using Ardalis.Result;
//using MediatR;
//using poc.core.api.net8.Interface;
//using Poc.Contract.Query.User.EF.Interface;
//using Poc.Contract.Query.User.EF.QueriesModel;
//using Poc.Contract.Query.User.Request;

//namespace Poc.Query.User;

//public class GetUserQueryHandler : IRequestHandler<GetUserQuery, Result<List<UserQueryModel>>>
//{
//    private readonly IUserReadOnlyRepository _repo;
//    private readonly IRedisCacheService<List<UserQueryModel>> _cacheService;
//    public GetUserQueryHandler(IUserReadOnlyRepository repo, IRedisCacheService<List<UserQueryModel>> cacheService)
//    {
//        _repo = repo;
//        _cacheService = cacheService;
//    }

//    public async Task<Result<List<UserQueryModel>>> Handle(GetUserQuery request, CancellationToken cancellationToken)
//    {
//        const string cacheKey = nameof(GetUserQuery);
//        return Result.Success(await _cacheService.GetOrCreateAsync(cacheKey, _repo.GetAllAsync, TimeSpan.FromHours(2)));
//    }
//}
