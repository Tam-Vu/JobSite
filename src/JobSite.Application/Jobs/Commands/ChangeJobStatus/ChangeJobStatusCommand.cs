using JobSite.Application.Common.Models;
using JobSite.Application.Jobs.Common;
using JobSite.Domain.Enums;

namespace JobSite.Application.Jobs.Commands.ChangeJobStatus;

public record ChangeJobStatusCommand
(
    Guid Id,
    int Status
) : IRequest<Result<JobCommandResponse>>;