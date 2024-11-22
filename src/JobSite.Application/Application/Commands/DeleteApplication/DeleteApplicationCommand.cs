
using JobSite.Application.Application.Common;
using JobSite.Application.Common.Models;

namespace JobSite.Application.Application.Commands.DeleteApplication;
public record DeleteApplicationCommand
(
    Guid JobId,
    Guid ResumeId
) : IRequest<Result<CommandApplicationResponse>>;

