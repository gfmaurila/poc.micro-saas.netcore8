using Common.Core._08.Response;

namespace API.Exemple1.Core._08.Feature.Exemple.Commands.Update;

public class UpdateExempleResponse : BaseResponse
{
    public UpdateExempleResponse(Guid id) => Id = id;
    public Guid Id { get; }
}
