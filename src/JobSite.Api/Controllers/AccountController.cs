using JobSite.Application.Accounts.Commands.CreateAccount;
using JobSite.Application.Accounts.Commands.VerifyAccount;
using JobSite.Application.Accounts.Queries.CurrentAccount;
using JobSite.Application.Accounts.Queries.Login;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobSite.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController(ISender _mediator) : ControllerBase
{

    [HttpPost]
    public async Task<string> CreateNewAccount(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        return await _mediator.Send(request, cancellationToken);
    }

    [HttpGet]
    [Route("ConfirmEmail")]
    public async Task<string> VerifyAccount([FromQuery] string email, string token, CancellationToken cancellationToken)
    {
        var request = new VerifyAccountCommand
        (
            email,
            token
        );
        return await _mediator.Send(request, cancellationToken);
    }

    [HttpPost]
    [Route("Login")]
    public async Task<LoginResponse> Login(LoginQuery request, CancellationToken cancellationToken)
    {
        return await _mediator.Send(request, cancellationToken);
    }

    [HttpGet]
    [Authorize]
    [Route("me")]
    public async Task<CurrentAccountResponse> CurrentAccount(CancellationToken cancellationToken)
    {
        var request = new CurrentAccountQuery();
        return await _mediator.Send(request, cancellationToken);
    }
}