using API.External.Auth.Feature.Notification.Request;
using Polly;
using System.Net;

namespace API.External.Auth.Feature.Notification.Service;

public class TwilioService : ITwilioService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<TwilioService> _logger;
    private readonly IConfiguration _configuration;
    private readonly AsyncPolicy<HttpResponseMessage> _retryPolicy;

    public TwilioService(HttpClient httpClient, ILogger<TwilioService> logger, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _logger = logger;
        _configuration = configuration;

        // Configuração da política de tentativas de retry
        _retryPolicy = Policy
            .Handle<HttpRequestException>()
            .OrResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
            .WaitAndRetryAsync(
                retryCount: _configuration.GetValue<int>(TwilioAppAuthConsts.RETRYCOUNT),
                sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                onRetry: (ex, retryCount, context) =>
                {
                    // Lógica a ser executada a cada tentativa de retry
                    _logger.LogWarning($"Tentativa {retryCount} de envio de celular...");
                }
            );
    }

    public async Task TwilioAsync(TwilioRequest request)
    {

        await _retryPolicy.ExecuteAsync(async () =>
        {
            request.Auth = new AuthDTO()
            {
                AccountSid = TwilioAppAuthConsts.AccountSid,
                AuthToken = TwilioAppAuthConsts.AuthToken,
                From = TwilioAppAuthConsts.From
            };

            var response = await _httpClient.PostAsJsonAsync(
                _configuration.GetValue<string>(TwilioAppAuthConsts.URL_CODE),
                request
            );

            response.EnsureSuccessStatusCode();

            if (response.StatusCode != HttpStatusCode.OK && response.StatusCode != HttpStatusCode.Accepted)
            {
                var error = await response.Content.ReadAsStringAsync();
                _logger.LogError($"Falha ao enviar sms ou whatsapp: {error}");
            }
            return response;
        });
    }
}
