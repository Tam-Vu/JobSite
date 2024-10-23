using JobSite.Application.Skills.Commands.DeleteSkill;
using JobSite.Application.Skills.Commands.UpdateSkill;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobSite.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SkillController(ISender _mediator) : ControllerBase
{

    [HttpPost]
    [Route("create-skill")]
    public async Task<string> CreateNewSkill(CreateSkillCommand request, CancellationToken cancellationToken)
    {
        return await _mediator.Send(request, cancellationToken);
    }

    [HttpPut]
    [Route("update-skill")]
    public async Task<string> UpdateSkill(UpdateSkillCommand request, CancellationToken cancellationToken)
    {
        return await _mediator.Send(request, cancellationToken);
    }

    [HttpDelete]
    [Route("delete-skill")]
    public async Task<string> DeleteSkill(DeleteSkillCommand request, CancellationToken cancellationToken)
    {
        return await _mediator.Send(request, cancellationToken);
    }
}