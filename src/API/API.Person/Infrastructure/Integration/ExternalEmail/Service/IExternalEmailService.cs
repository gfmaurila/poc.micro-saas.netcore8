using API.Person.Feature.External.ExternalEmail.Get;
using API.Person.Feature.External.ExternalEmail.Get.Model;
using API.Person.Infrastructure.Integration.ExternalEmail.Model;

namespace API.Person.Infrastructure.Integration.ExternalEmail.Service;

public interface IExternalEmailService
{
    Task<CreateSendResponse> SendMessageAsync(CreateSendRequest request);
    Task<List<ListSendResponse>> GetListSendAsync();
    Task<List<EmailQueryModel>> GetPaginatedItemsAsync(GetPaginateEmailQuery query);
    Task<int> GetTotalCountAsync();
}
