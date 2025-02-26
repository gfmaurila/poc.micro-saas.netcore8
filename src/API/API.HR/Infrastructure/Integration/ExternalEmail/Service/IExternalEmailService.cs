using API.HR.Feature.External.ExternalEmail.Get;
using API.HR.Feature.External.ExternalEmail.Get.Model;
using API.HR.Infrastructure.Integration.ExternalEmail.Model;

namespace API.HR.Infrastructure.Integration.ExternalEmail.Service;

public interface IExternalEmailService
{
    Task<CreateSendResponse> SendMessageAsync(CreateSendRequest request);
    Task<List<ListSendResponse>> GetListSendAsync();
    Task<List<EmailQueryModel>> GetPaginatedItemsAsync(GetPaginateEmailQuery query);
    Task<int> GetTotalCountAsync();
}
