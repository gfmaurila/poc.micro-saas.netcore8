using API.Clinic.Feature.External.ExternalEmail.Get;
using API.Clinic.Feature.External.ExternalEmail.Get.Model;
using API.Clinic.Infrastructure.Integration.ExternalEmail.Model;

namespace API.Clinic.Infrastructure.Integration.ExternalEmail.Service;

public interface IExternalEmailService
{
    Task<CreateSendResponse> SendMessageAsync(CreateSendRequest request);
    Task<List<ListSendResponse>> GetListSendAsync();
    Task<List<EmailQueryModel>> GetPaginatedItemsAsync(GetPaginateEmailQuery query);
    Task<int> GetTotalCountAsync();
}
