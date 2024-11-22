
using JobSite.Application.Application.Common;
using JobSite.Application.Common.Models;

namespace JobSite.Application.Application.Commands.CreateApplication;
public record CreateApplicationCommand
(
    Guid JobId,
    Guid ResumeId
) : IRequest<Result<CommandApplicationResponse>>;

