using Poc.Auth.Twilio.Response;
using Poc.Contract.Command.TryWhatsApp.Request;
using Twilio.Rest.Api.V2010.Account;

namespace Poc.Auth.Twilio.Mapper;

public static class TwilioMapper
{
    public static TwilioMessageResponse MapTwilioMessageResponseToMessageResponse(MessageResource message, CreateCalendarAlertCommand request)
    {
        var response = new TwilioMessageResponse
        {
            AccountSid = message.AccountSid,
            ApiVersion = message.ApiVersion,
            Body = message.Body,
            DateCreated = message.DateCreated ?? DateTime.Now,
            DateSent = message.DateSent,
            DateUpdated = message.DateUpdated ?? DateTime.Now,
            Direction = message.Direction.ToString(),
            ErrorCode = message.ErrorCode,
            ErrorMessage = message.ErrorMessage,
            From = message.From.ToString(),
            NumMedia = message.NumMedia,
            NumSegments = message.NumSegments,
            Price = message.Price?.ToString(),
            PriceUnit = message.PriceUnit,
            Sid = message.Sid,
            Status = message.Status.ToString(),
            To = message.To.ToString(),
            Uri = message.Uri,
            RequestCreateCalendarAlert = request
        };

        return response;
    }

    public static TwilioMessageResponse MapTwilioMessageResponseToMessageResponse(MessageResource message, CreateCodeCommand request)
    {
        var response = new TwilioMessageResponse
        {
            AccountSid = message.AccountSid,
            ApiVersion = message.ApiVersion,
            Body = message.Body,
            DateCreated = message.DateCreated ?? DateTime.Now,
            DateSent = message.DateSent,
            DateUpdated = message.DateUpdated ?? DateTime.Now,
            Direction = message.Direction.ToString(),
            ErrorCode = message.ErrorCode,
            ErrorMessage = message.ErrorMessage,
            From = message.From.ToString(),
            NumMedia = message.NumMedia,
            NumSegments = message.NumSegments,
            Price = message.Price?.ToString(),
            PriceUnit = message.PriceUnit,
            Sid = message.Sid,
            Status = message.Status.ToString(),
            To = message.To.ToString(),
            Uri = message.Uri,
            RequestCreateCode = request
        };

        return response;
    }


    public static TwilioMessageResponse MapCreateCalendarAlertCommandToMessageResponse(Exception message, CreateCalendarAlertCommand command)
    {
        return new TwilioMessageResponse()
        {
            RequestCreateCalendarAlert = command,
            ErrorMessage = message.Message
        };
    }

    public static TwilioMessageResponse MapCreateCalendarAlertCommandToMessageResponse(Exception message, CreateCodeCommand command)
    {
        return new TwilioMessageResponse()
        {
            RequestCreateCode = command,
            ErrorMessage = message.Message
        };
    }
}
