using API.Freelancer.Feature.External.ExternalEmail.Get;
using API.Freelancer.Feature.External.ExternalEmail.Get.Model;
using API.Freelancer.Infrastructure.Integration.ExternalEmail.Model;

namespace API.Freelancer.Infrastructure.Integration.ExternalEmail.Service;

public interface IExternalEmailService
{
    Task<CreateSendResponse> SendMessageAsync(CreateSendRequest request);
    Task<List<ListSendResponse>> GetListSendAsync();
    Task<List<EmailQueryModel>> GetPaginatedItemsAsync(GetPaginateEmailQuery query);
    Task<int> GetTotalCountAsync();
}
