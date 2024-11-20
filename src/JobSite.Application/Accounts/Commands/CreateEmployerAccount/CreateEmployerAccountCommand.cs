using JobSite.Application.Accounts.Common;
using JobSite.Application.Common.Models;
using JobSite.Domain.Enums;
namespace JobSite.Application.Accounts.Commands.CreateEmployerAccountCommand;

public record CreateEmployerAccountCommand
(
    string UserName,
    string Email,
    string Password,
    string ConfirmPassword,
    string PhoneNumber,
    string Name,
    string Description,
    Sector Sector,
    string? Location,
    string? Website
) : IRequest<Result<AccountCommandResponse>>;