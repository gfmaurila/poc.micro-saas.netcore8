//using Ardalis.Result;
//using Ardalis.Result.FluentValidation;
//using MediatR;
//using poc.core.api.net8.Interface;
//using Poc.Contract.Query.User.EF.Interface;
//using Poc.Contract.Query.User.EF.QueriesModel;
//using Poc.Contract.Query.User.Request;
//using Poc.Contract.Query.User.Validators;

//namespace Poc.Query.User;

//public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, Result<UserQueryModel>>
//{
//    private readonly IUserReadOnlyRepository _repo;
//    private readonly IRedisCacheService<UserQueryModel> _cacheService;
//    private readonly GetUserByIdQueryValidator _validator;
//    public GetUserByIdQueryHandler(IUserReadOnlyRepository repo,
//                                   IRedisCacheService<UserQueryModel> cacheService,
//                                   GetUserByIdQueryValidator validator)
//    {
//        _repo = repo;
//        _cacheService = cacheService;
//        _validator = validator;
//    }

//    public async Task<Result<UserQueryModel>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
//    {
//        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
//        if (!validationResult.IsValid)
//            return Result.Invalid(validationResult.AsErrors());

//        var cacheKey = $"{nameof(GetUserByIdQuery)}_{request.Id}";

//        var model = await _cacheService.GetOrCreateAsync(cacheKey, () => _repo.GetByIdAsync(request.Id), TimeSpan.FromHours(2));
//        if (model == null)
//            return Result.NotFound($"Nenhum registro encontrado pelo Id: {request.Id}");

//        return Result.Success(model);
//    }

//}
