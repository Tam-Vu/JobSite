using JobSite.Application.Accounts.Common;
using JobSite.Application.Common.Models;
namespace JobSite.Application.Accounts.Commands.CreateEmployeeAccountCommand;

public record CreateEmployeeAccountCommand
(
    string UserName,
    string Email,
    string Password,
    string ConfirmPassword,
    string PhoneNumber,
    string Fullname,
    string Address
) : IRequest<Result<AccountCommandResponse>>;