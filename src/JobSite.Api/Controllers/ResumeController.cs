using JobSite.Application.Common.Models;
using JobSite.Application.Resumes.Commands;
using JobSite.Application.Resumes.Commands.CreateResumeCommand;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobSite.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class ResumeController(IMediator _mediator) : ControllerBase
{

    [HttpPost]
    public async Task<Result<ResponseResumeCommand>> CreateNewResume(CreateResumeCommand request, CancellationToken cancellationToken)
    {
        return await _mediator.Send(request, cancellationToken);
    }
}