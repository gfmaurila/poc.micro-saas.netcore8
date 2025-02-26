using API.Exemple.Core._08.Feature.External.ExternalEmail.Get;
using API.Exemple.Core._08.Feature.External.ExternalEmail.Get.Model;
using API.Exemple.Core._08.Infrastructure.Integration.ExternalEmail.Model;

namespace API.Exemple.Core._08.Infrastructure.Integration.ExternalEmail.Service;

public interface IExternalEmailService
{
    Task<CreateSendResponse> SendMessageAsync(CreateSendRequest request);
    Task<List<ListSendResponse>> GetListSendAsync();
    Task<List<EmailQueryModel>> GetPaginatedItemsAsync(GetPaginateEmailQuery query);
    Task<int> GetTotalCountAsync();
}
