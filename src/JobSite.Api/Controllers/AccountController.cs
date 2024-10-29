using JobSite.Application.Accounts.Commands.CreateAccount;
using JobSite.Application.Accounts.Commands.VerifyAccount;
using JobSite.Application.Common.Models;
using JobSite.Application.Jobs;
using JobSite.Application.Jobs.Commands.CreateJob;
using MediatR;
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

    [HttpPost]
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
}