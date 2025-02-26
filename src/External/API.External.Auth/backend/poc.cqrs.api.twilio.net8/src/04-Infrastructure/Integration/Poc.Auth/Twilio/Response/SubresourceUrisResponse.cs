using Newtonsoft.Json;

namespace Poc.Auth.Twilio.Response;

public class SubresourceUrisResponse
{
    [JsonProperty("media")]
    public string Media { get; set; }
}
