namespace JobSite.Application.Accounts.Commands.CreateAccount;

public record CreateAccountCommand
(
    string UserName,
    string Email,
    string Password,
    string ConfirmPassword,
    string PhoneNumber
) : IRequest<string>;