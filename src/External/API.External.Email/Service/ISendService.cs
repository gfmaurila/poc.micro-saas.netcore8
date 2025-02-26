using API.External.Email.Model;

namespace poc.api.redis.Service;

public interface ISendService
{
    Task<SendResponseModel> Post(SendModel entity);
    Task<List<SendModel>> Get();
}
