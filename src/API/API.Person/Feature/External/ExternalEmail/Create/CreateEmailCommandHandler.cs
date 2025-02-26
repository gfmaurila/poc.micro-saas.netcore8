using API.Person.Feature.External.ExternalEmail.Create.Model;
using API.Person.Infrastructure.Integration.ExternalEmail.Model;
using API.Person.Infrastructure.Integration.ExternalEmail.Service;
using Common.Core._08.Response;
using MediatR;

namespace API.Person.Feature.External.ExternalEmail.Create;



/// <summary>
/// Handles the creation of an email request by sending the message through an external email service.
/// </summary>
public class CreateEmailCommandHandler : IRequestHandler<CreateEmailCommand, ApiResult<CreateEmailResponse>>
{
    private readonly IExternalEmailService _emailService;
    private readonly ILogger<CreateEmailCommandHandler> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateEmailCommandHandler"/> class.
    /// </summary>
    /// <param name="logger">Logger instance for logging operations.</param>
    /// <param name="emailService">External email service used to send messages.</param>
    public CreateEmailCommandHandler(ILogger<CreateEmailCommandHandler> logger, IExternalEmailService emailService)
    {
        _emailService = emailService;
        _logger = logger;
    }

    /// <summary>
    /// Handles the request to send an email through the external service.
    /// </summary>
    /// <param name="request">The command containing the email details.</param>
    /// <param name="cancellationToken">Cancellation token to handle request cancellation.</param>
    /// <returns>An <see cref="ApiResult{T}"/> containing the response details.</returns>
    public async Task<ApiResult<CreateEmailResponse>> Handle(CreateEmailCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Processing email send request.");

        // Calls the external email service to send the message.
        var response = await _emailService.SendMessageAsync(new CreateSendRequest()
        {
            Notification = request.request.Notification,
            Id = request.request.Id,
            To = request.request.To,
            Auth = new ExternalEmailAuth()
            {
                AccountSid = request.request.Auth.AccountSid,
                AuthToken = request.request.Auth.AuthToken,
                From = request.request.Auth.From,
            },
            Body = request.request.Body
        });

        _logger.LogInformation("Email send request processed successfully. Response code: {Code}", response.Code);

        return ApiResult<CreateEmailResponse>.CreateSuccess(new CreateEmailResponse(new CreateEmailResponseModel()
        {
            Code = response.Code,
            DtSend = response.DtSend,
            Request = new EmailRequestModel()
            {
                Id = response.Request.Id,
                Body = response.Request.Body,
                Notification = response.Request.Notification,
                To = response.Request.To,
                Auth = new AuthEmailModel()
                {
                    AccountSid = response.Request.Auth.AccountSid,
                    AuthToken = response.Request.Auth.AuthToken,
                    From = response.Request.Auth.From,
                }
            }
        }), "Successfully registered!");
    }
}


