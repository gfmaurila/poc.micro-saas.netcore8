using API.Customer.Feature.External.ExternalEmail.Get;
using API.Customer.Feature.External.ExternalEmail.Get.Model;
using API.Customer.Infrastructure.Integration.ExternalEmail.Model;

namespace API.Customer.Infrastructure.Integration.ExternalEmail.Service;

public interface IExternalEmailService
{
    Task<CreateSendResponse> SendMessageAsync(CreateSendRequest request);
    Task<List<ListSendResponse>> GetListSendAsync();
    Task<List<EmailQueryModel>> GetPaginatedItemsAsync(GetPaginateEmailQuery query);
    Task<int> GetTotalCountAsync();
}
