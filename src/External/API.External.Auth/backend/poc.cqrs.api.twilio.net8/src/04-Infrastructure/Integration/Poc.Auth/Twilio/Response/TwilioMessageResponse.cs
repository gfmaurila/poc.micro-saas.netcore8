using Newtonsoft.Json;
using Poc.Contract.Command.TryWhatsApp.Request;

namespace Poc.Auth.Twilio.Response;

public class TwilioMessageResponse
{
    [JsonProperty("account_sid")]
    public string AccountSid { get; set; }

    [JsonProperty("api_version")]
    public string ApiVersion { get; set; }

    [JsonProperty("body")]
    public string Body { get; set; }

    [JsonProperty("date_created")]
    public DateTime DateCreated { get; set; }

    [JsonProperty("date_sent")]
    public DateTime? DateSent { get; set; }

    [JsonProperty("date_updated")]
    public DateTime DateUpdated { get; set; }

    [JsonProperty("direction")]
    public string Direction { get; set; }

    [JsonProperty("error_code")]
    public int? ErrorCode { get; set; }

    [JsonProperty("error_message")]
    public string ErrorMessage { get; set; }

    [JsonProperty("from")]
    public string From { get; set; }

    [JsonProperty("messaging_service_sid")]
    public string MessagingServiceSid { get; set; }

    [JsonProperty("num_media")]
    public string NumMedia { get; set; }

    [JsonProperty("num_segments")]
    public string NumSegments { get; set; }

    [JsonProperty("price")]
    public string Price { get; set; }

    [JsonProperty("price_unit")]
    public string PriceUnit { get; set; }

    [JsonProperty("sid")]
    public string Sid { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("subresource_uris")]
    public SubresourceUrisResponse SubresourceUris { get; set; }

    [JsonProperty("to")]
    public string To { get; set; }

    [JsonProperty("uri")]
    public string Uri { get; set; }

    public CreateCalendarAlertCommand RequestCreateCalendarAlert { get; set; }
    public CreateCodeCommand RequestCreateCode { get; set; }

}

