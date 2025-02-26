using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poc.Contract.Command.StatusCallbackURL.Request.DTO;
public class CreateStatusCallbackURLConfirmDTO
{
    public string SmsMessageSid { get; set; } = String.Empty;       
    public int NumMedia { get; set; } = 0;
    public string ProfileName { get; set; } = String.Empty;
    public string MessageType { get; set; } = String.Empty;
    public string SmsSid { get; set; } = String.Empty;
    public string WaId { get; set; } = String.Empty;    
    public string SmsStatus { get; set; } = String.Empty;
    public string Body { get; set; } = String.Empty;
    public string ButtonText { get; set; } = String.Empty;
    public string To { get; set; } = String.Empty;
    public string ButtonPayload { get; set; } = String.Empty;
    public int NumSegments { get; set; } = 0;
    public int ReferralNumMedia { get; set; } = 0;
    public string MessageSid { get; set; } = String.Empty;
    public string AccountSid { get; set; } = String.Empty;
    public string From { get; set; } = String.Empty;
    public string ApiVersion { get; set; } = String.Empty;
}
