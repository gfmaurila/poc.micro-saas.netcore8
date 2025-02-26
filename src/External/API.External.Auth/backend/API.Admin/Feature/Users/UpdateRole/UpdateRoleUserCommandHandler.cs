using API.External.Auth.Infrastructure.Database.Repositories.Interfaces;
using Common.External.Auth.Net8.Response;
using MediatR;

namespace API.External.Auth.Feature.Users.UpdateRole;

public class UpdateRoleUserCommandHandler : IRequestHandler<UpdateRoleUserCommand, ApiResult<UpdateRoleUserResponse>>
{
    private readonly UpdateRoleUserCommandValidator _validator;
    private readonly IUserRepository _repo;
    private readonly ILogger<UpdateRoleUserCommandHandler> _logger;
    private readonly IMediator _mediator;
    public UpdateRoleUserCommandHandler(ILogger<UpdateRoleUserCommandHandler> logger,
                                    IUserRepository repo,
                                    UpdateRoleUserCommandValidator validator,
                                    IMediator mediator)
    {
        _repo = repo;
        _logger = logger;
        _validator = validator;
        _mediator = mediator;
    }
    public async Task<ApiResult<UpdateRoleUserResponse>> Handle(UpdateRoleUserCommand request, CancellationToken cancellationToken)
    {
        // Obtendo o registro da base.
        var entity = await _repo.Get(request.Id);
        if (entity == null)
            if (entity == null)
                return ApiResult<UpdateRoleUserResponse>.CreateError(
                    new List<ErrorDetail> {
                    new ErrorDetail($"Nenhum registro encontrado pelo Id: {request.Id}")
                    },
                    400);

        entity.UpdateRole(request.RoleUserAuth);

        await _repo.Update(entity);

        // Executa eventos
        foreach (var domainEvent in entity.DomainEvents)
            await _mediator.Publish(domainEvent);

        entity.ClearDomainEvents();

        return ApiResult<UpdateRoleUserResponse>.CreateSuccess(new UpdateRoleUserResponse(entity.Id), "Atualizado com sucesso!");
    }
}
