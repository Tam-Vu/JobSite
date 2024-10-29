using JobSite.Application.Common.Models;
namespace JobSite.Application.IRepository;
public interface IEmailSenderRepository
{
    Task SendEmailAsync(EmailMetadata emailMetadata, CancellationToken cancellationToken);
    Task SendEmailConfirmationAsync(string email, string token, CancellationToken cancellationToken);
}