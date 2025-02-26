using Microsoft.Extensions.Logging;
using poc.core.api.net8.Enumerado;
using poc.core.api.net8.Interface;
using Poc.Auth.Twilio.Interfaces;
using Poc.Auth.Twilio.Mapper;
using Poc.Auth.Twilio.Response;
using Poc.Contract.Command.TryWhatsApp.Request;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Poc.Auth.Twilio.Services;

public class TwilioService : ITwilioService
{
    private readonly ILogger<TwilioService> _logger;
    private readonly IRedisCacheService<TwilioMessageResponse> _redis;

    public TwilioService(ILogger<TwilioService> logger,
                         IRedisCacheService<TwilioMessageResponse> redis)
    {
        _logger = logger;
        _redis = redis;
    }

    public async Task<TwilioMessageResponse> CalendarAlertAsync(CreateCalendarAlertCommand request)
    {
        string cacheKey = nameof(TwilioMessageResponse);

        try
        {
            TwilioClient.Init(request.Auth.AccountSid, request.Auth.AuthToken);
            var response = new TwilioMessageResponse();

            if (request.Notification == ENotificationType.WhatsApp)
            {
                cacheKey = nameof(TwilioMessageResponse) + "_WHATSAPP_AGENDA_" + Guid.NewGuid().ToString();
                response = await CreateWhatsAppAgenda(request);
            }

            if (request.Notification == ENotificationType.SMS)
            {
                cacheKey = nameof(TwilioMessageResponse) + "_SMS_AGENDA_" + Guid.NewGuid().ToString();
                response = await CreateSMS(request);
            }
            await _redis.SetAsync(cacheKey, response);
            return response;
        }
        catch (Exception ex)
        {
            var response = TwilioMapper.MapCreateCalendarAlertCommandToMessageResponse(ex, request);
            await _redis.SetAsync(cacheKey, response);
            return response;
        }
    }

    public async Task<TwilioMessageResponse> CodeAsync(CreateCodeCommand request)
    {
        string cacheKey = nameof(TwilioMessageResponse);

        try
        {
            TwilioClient.Init(request.Auth.AccountSid, request.Auth.AuthToken);

            var response = new TwilioMessageResponse();

            if (request.Notification == ENotificationType.WhatsApp)
            {
                cacheKey = nameof(TwilioMessageResponse) + "_WHATSAPP_CODE_" + Guid.NewGuid().ToString();
                response = await CreateWhatsAppCode(request);
            }

            if (request.Notification == ENotificationType.SMS)
            {
                cacheKey = nameof(TwilioMessageResponse) + "_SMS_CODE_" + Guid.NewGuid().ToString();
                response = await CreateSMS(request);
            }

            await _redis.SetAsync(cacheKey, response);

            return response;
        }
        catch (Exception ex)
        {
            var response = TwilioMapper.MapCreateCalendarAlertCommandToMessageResponse(ex, request);
            await _redis.SetAsync(cacheKey, response);
            return response;
        }
    }


    #region Private
    private async Task<TwilioMessageResponse> CreateSMS(CreateCalendarAlertCommand request)
    {
        var messageOptions = new CreateMessageOptions(new PhoneNumber(request.To));
        messageOptions.From = new PhoneNumber(request.Auth.From);
        messageOptions.Body = request.Body;
        var message = MessageResource.Create(messageOptions);

        var response = TwilioMapper.MapTwilioMessageResponseToMessageResponse(message, request);

        if (message.SubresourceUris != null)
        {
            response.SubresourceUris = new SubresourceUrisResponse
            {
                Media = message.SubresourceUris.ToString()
            };
        }
        return response;
    }

    private async Task<TwilioMessageResponse> CreateSMS(CreateCodeCommand request)
    {
        var messageOptions = new CreateMessageOptions(new PhoneNumber(request.To));
        messageOptions.From = new PhoneNumber(request.Auth.From);
        messageOptions.Body = request.Body;
        var message = MessageResource.Create(messageOptions);

        var response = TwilioMapper.MapTwilioMessageResponseToMessageResponse(message, request);

        if (message.SubresourceUris != null)
        {
            response.SubresourceUris = new SubresourceUrisResponse
            {
                Media = message.SubresourceUris.ToString()
            };
        }
        return response;
    }

    private async Task<TwilioMessageResponse> CreateWhatsAppAgenda(CreateCalendarAlertCommand request)
    {
        var message = await MessageResource.CreateAsync(
                body: request.Body,
                from: new PhoneNumber(request.Auth.From),
                to: new PhoneNumber(request.To)
            );

        var response = TwilioMapper.MapTwilioMessageResponseToMessageResponse(message, request);

        if (message.SubresourceUris != null)
        {
            response.SubresourceUris = new SubresourceUrisResponse
            {
                Media = message.SubresourceUris.ToString()
            };
        }
        return response;
    }

    private async Task<TwilioMessageResponse> CreateWhatsAppCode(CreateCodeCommand request)
    {
        var message = await MessageResource.CreateAsync(
                body: request.Body,
                from: new PhoneNumber(request.Auth.From),
                to: new PhoneNumber(request.To)
            );

        var response = TwilioMapper.MapTwilioMessageResponseToMessageResponse(message, request);

        if (message.SubresourceUris != null)
        {
            response.SubresourceUris = new SubresourceUrisResponse
            {
                Media = message.SubresourceUris.ToString()
            };
        }
        return response;
    }
    #endregion
}
