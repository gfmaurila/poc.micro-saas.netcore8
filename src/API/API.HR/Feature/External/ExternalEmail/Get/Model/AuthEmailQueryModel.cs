﻿namespace API.HR.Feature.External.ExternalEmail.Get.Model;

public class AuthEmailQueryModel
{
    public string AccountSid { get; set; }
    public string AuthToken { get; set; }
    public string From { get; set; }
}
