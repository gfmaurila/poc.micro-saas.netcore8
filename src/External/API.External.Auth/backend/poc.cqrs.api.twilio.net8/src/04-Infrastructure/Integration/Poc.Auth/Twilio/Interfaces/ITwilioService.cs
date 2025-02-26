using Poc.Auth.Twilio.Response;
using Poc.Contract.Command.TryWhatsApp.Request;

namespace Poc.Auth.Twilio.Interfaces;

public interface ITwilioService
{
    Task<TwilioMessageResponse> CalendarAlertAsync(CreateCalendarAlertCommand dto);
    Task<TwilioMessageResponse> CodeAsync(CreateCodeCommand dto);
}
