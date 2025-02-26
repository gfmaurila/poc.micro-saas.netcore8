using API.External.Auth.Feature.Users.GetUser;
using API.External.Auth.Infrastructure.Database.Repositories.Interfaces;
using Common.External.Auth.Net8.Interface;
using Common.External.Auth.Net8.Response;
using MediatR;

namespace API.External.Auth.Feature.Users.GetUserById;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, ApiResult<UserQueryModel>>
{
    private readonly IUserRepository _repo;
    private readonly IRedisCacheService<UserQueryModel> _cacheService;
    private readonly GetUserByIdQueryValidator _validator;
    public GetUserByIdQueryHandler(IUserRepository repo,
                                   IRedisCacheService<UserQueryModel> cacheService,
                                   GetUserByIdQueryValidator validator)
    {
        _repo = repo;
        _cacheService = cacheService;
        _validator = validator;
    }

    public async Task<ApiResult<UserQueryModel>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return ApiResult<UserQueryModel>.CreateError(
                validationResult.Errors.Select(e => new ErrorDetail(e.ErrorMessage)).ToList(),
                400);

        var cacheKey = $"{nameof(GetUserByIdQuery)}_{request.Id}";

        var modelRedis = await _cacheService.GetAsync(cacheKey);

        // Db Redis
        if (modelRedis is not null)
            return ApiResult<UserQueryModel>.CreateSuccess(
                modelRedis,
                "Usuário recuperado com sucesso.");

        var entity = await _repo.GetByIdAsync(request.Id);

        // DB SQL Server
        if (entity is not null)
            return ApiResult<UserQueryModel>.CreateSuccess(
                await _cacheService.GetOrCreateAsync(cacheKey, () => _repo.GetByIdAsync(request.Id), TimeSpan.FromHours(2)),
                "Usuário recuperado com sucesso.");

        return ApiResult<UserQueryModel>.CreateSuccess(entity, "Nenhum registro encontrado!");
    }

}