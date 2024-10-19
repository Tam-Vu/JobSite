
using JobSite.Application.Jobs.Commands.CreateJob;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobSite.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JobController(ISender _mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateNewJob(CreateJobCommand request)
    {
        Console.WriteLine("CreateNewJob");
        var response = await _mediator.Send(request);
        return Ok(response);
    }
}