using JobSite.Application.Common.Models;
using JobSite.Application.Skills.Commands.DeleteSkill;
using JobSite.Application.Skills.Commands.UpdateSkill;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobSite.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SkillController(ISender _mediator) : ControllerBase
{

    [HttpPost]
    [Route("")]

    public async Task<Result<string>> CreateNewSkill(CreateSkillCommand request, CancellationToken cancellationToken)
    {
        return await _mediator.Send(request, cancellationToken);
    }

    [HttpPut]
    [Route("")]
    public async Task<string> UpdateSkill(UpdateSkillCommand request, CancellationToken cancellationToken)
    {
        return await _mediator.Send(request, cancellationToken);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<string> DeleteSkill(Guid id, CancellationToken cancellationToken)
    {
        var request = new DeleteSkillCommand(id);
        return await _mediator.Send(request, cancellationToken);
    }

    [HttpGet]
    [Route("")]
    public async Task<List<SkillResponseData>> GetListSkill(CancellationToken cancellationToken)
    {
        var request = new GetListSkillQuery();
        return await _mediator.Send(request, cancellationToken);
    }
}