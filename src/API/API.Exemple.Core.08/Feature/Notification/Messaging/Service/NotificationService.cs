using API.Exemple.Core._08.Infrastructure.Integration;
using API.Exemple1.Core._08.Feature.Notification.Messaging.Request;
using Polly;
using System.Net;

namespace API.Exemple1.Core._08.Feature.Notification.Messaging.Service;

/// <summary>
/// Service responsible for sending notifications via SMS or WhatsApp using an external API.
/// Implements retry policies to handle failures in HTTP requests.
/// </summary>
public class NotificationService : INotificationService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<NotificationService> _logger;
    private readonly IConfiguration _configuration;
    private readonly AsyncPolicy<HttpResponseMessage> _retryPolicy;

    /// <summary>
    /// Initializes a new instance of the <see cref="NotificationService"/> class.
    /// </summary>
    /// <param name="httpClient">The HTTP client for making API requests.</param>
    /// <param name="logger">Logger instance for logging operations.</param>
    /// <param name="configuration">Configuration instance for retrieving API settings.</param>
    public NotificationService(HttpClient httpClient, ILogger<NotificationService> logger, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _logger = logger;
        _configuration = configuration;

        // Configures the retry policy for handling transient HTTP failures
        _retryPolicy = Policy
            .Handle<HttpRequestException>()
            .OrResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
            .WaitAndRetryAsync(
                retryCount: _configuration.GetValue<int>(ApiConsts.RETRYCOUNT),
                sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                onRetry: (ex, retryCount, context) =>
                {
                    _logger.LogWarning($"Retry attempt {retryCount} for sending message...");
                }
            );
    }

    /// <summary>
    /// Sends a notification request (SMS or WhatsApp) using the configured external API.
    /// </summary>
    /// <param name="request">The notification request containing recipient and message details.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task NotificationAsync(NotificationRequest request)
    {
        await _retryPolicy.ExecuteAsync(async () =>
        {
            request.Auth = new AuthNotification
            {
                AccountSid = _configuration.GetValue<string>(ApiConsts.AccountSid),
                AuthToken = _configuration.GetValue<string>(ApiConsts.AuthToken),
                From = _configuration.GetValue<string>(ApiConsts.From)
            };

            var response = await _httpClient.PostAsJsonAsync(
                _configuration.GetValue<string>(ApiConsts.BaseUrl),
                request
            );

            response.EnsureSuccessStatusCode();

            if (response.StatusCode != HttpStatusCode.OK && response.StatusCode != HttpStatusCode.Accepted)
            {
                var error = await response.Content.ReadAsStringAsync();
                _logger.LogError($"Failed to send SMS or WhatsApp message: {error}");
            }
            return response;
        });
    }
}
