using API.InventoryControl.Feature.External.ExternalEmail.Get;
using API.InventoryControl.Feature.External.ExternalEmail.Get.Model;
using API.InventoryControl.Infrastructure.Integration.ExternalEmail.Model;

namespace API.InventoryControl.Infrastructure.Integration.ExternalEmail.Service;

public interface IExternalEmailService
{
    Task<CreateSendResponse> SendMessageAsync(CreateSendRequest request);
    Task<List<ListSendResponse>> GetListSendAsync();
    Task<List<EmailQueryModel>> GetPaginatedItemsAsync(GetPaginateEmailQuery query);
    Task<int> GetTotalCountAsync();
}
