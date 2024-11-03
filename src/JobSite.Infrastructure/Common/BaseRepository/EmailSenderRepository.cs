using FluentEmail.Core;
using JobSite.Application.Common.Models;
using JobSite.Infrastructure.Common.Security.BindingEnvClasses;
namespace JobSite.Infrastructure.Common.BaseRepository;
public class EmailSenderRepository : IEmailSenderRepository
{
    private readonly IFluentEmail _fluentEmail;
    // private readonly IConfiguration _configuration;
    public EmailSenderRepository(IFluentEmail fluentEmail)
    {
        _fluentEmail = fluentEmail;
        // _configuration = configuration;
    }
    public async Task SendEmailAsync(EmailMetadata emailMetadata, CancellationToken cancellationToken)
    {
        await _fluentEmail.To(emailMetadata.To)
            .Subject(emailMetadata.Subject)
            .Body(emailMetadata.Body)
            .SendAsync(cancellationToken);
    }
    public async Task SendEmailConfirmationAsync(string email, string token, CancellationToken cancellationToken)
    {
        // var webServer = _configuration.GetSection("WebServer").Get<WebServer>();
        await _fluentEmail.To(email)
            .Subject("Confirm your email")
            .Body($"<html><body> Please confirm your email by clicking this <a href='http://localhost:5257/api/Account/ConfirmEmail?email={email}&token={token}'>link</a> </body></html>", true)
            .SendAsync(cancellationToken);
    }
}