using JobSite.Application.Common.Interfaces;
using JobSite.Application.IRepository;
using JobSite.Domain.Entities;
using JobSite.Domain.Events;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace JobSite.Application.Accounts.Events;
public class AccountCreatedEventHandler : INotificationHandler<AccountCreatedEvent>
{
    // private readonly IApplicationDbContext _context;
    private readonly ILogger<AccountCreatedEventHandler> _logger;
    private readonly IEmailSenderRepository _emailSenderRepository;
    private readonly UserManager<Account> _userManager;

    public AccountCreatedEventHandler(ILogger<AccountCreatedEventHandler> logger, IEmailSenderRepository emailSenderRepository, UserManager<Account> userManager)
    {
        _logger = logger;
        _emailSenderRepository = emailSenderRepository;
        _userManager = userManager;
    }

    public async Task Handle(AccountCreatedEvent notification, CancellationToken cancellationToken)
    {
        if (notification.Account.Email == null) return;
        _logger.LogInformation("JobSite Domain Event: {DomainEvent}", notification.GetType().Name);
        Console.WriteLine("JobSite Domain Event: {DomainEvent}", notification.GetType().Name);
        var token = await _userManager.GenerateEmailConfirmationTokenAsync(notification.Account);
        await _emailSenderRepository.SendEmailConfirmationAsync(notification.Account.Email, token, cancellationToken);
    }
}
