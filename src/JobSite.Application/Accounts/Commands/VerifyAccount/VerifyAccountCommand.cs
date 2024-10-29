namespace JobSite.Application.Accounts.Commands.VerifyAccount;

public record VerifyAccountCommand
(
    string Email,
    string Token
) : IRequest<string>;