using Common.Core._08.Response;

namespace API.Exemple.Core._08.Feature.Notification;

public class CreateNotificationResponse : BaseResponse
{
    public CreateNotificationResponse(Guid id) => Id = id;

    public Guid Id { get; }
}


