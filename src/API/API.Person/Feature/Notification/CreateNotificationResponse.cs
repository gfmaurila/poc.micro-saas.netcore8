using Common.Core._08.Response;

namespace API.Person.Feature.Notification;

public class CreateNotificationResponse : BaseResponse
{
    public CreateNotificationResponse(Guid id) => Id = id;

    public Guid Id { get; }
}


