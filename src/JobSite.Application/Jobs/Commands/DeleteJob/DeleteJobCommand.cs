using JobSite.Application.Common.Models;

namespace JobSite.Application.Jobs.Commands.DeleteJob;

public record DeleteJobCommand
(
    Guid Id
) : IRequest<Result<string>>;