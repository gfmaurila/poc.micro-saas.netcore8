﻿namespace Common.External.Auth.Net8.Model;

public class Notification
{
    public Notification(string message)
    {
        Message = message;
    }

    public string Message { get; }
}
