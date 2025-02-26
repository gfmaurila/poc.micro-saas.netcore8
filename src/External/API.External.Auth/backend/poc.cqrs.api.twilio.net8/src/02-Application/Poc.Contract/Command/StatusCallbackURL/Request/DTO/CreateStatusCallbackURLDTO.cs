using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poc.Contract.Command.StatusCallbackURL.Request.DTO;
public class CreateStatusCallbackURLDTO
{
    public string ChannelPrefix { get; set; } = String.Empty;
    public string ApiVersion { get; set; } = String.Empty;
    public string MessageStatus { get; set; } = String.Empty;
    public string SmsSid { get; set; } = String.Empty;
    public string SmsStatus { get; set; } = String.Empty;
    public string ChannelInstallSid { get; set; } = String.Empty;
    public string To { get; set; } = String.Empty;
    public string From { get; set; } = String.Empty;
    public string MessageSid { get; set; } = String.Empty;
    public string AccountSid { get; set; } = String.Empty;
    public string ChannelToAddress { get; set; } = String.Empty;
}
