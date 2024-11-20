using JobSite.Application.Common.Models;
using JobSite.Application.Jobs.Common;
using JobSite.Domain.Enums;

namespace JobSite.Application.Jobs.Commands.UpdateJob;

public record UpdateJobCommand(
    Guid id,
    string title,
    string description,
    string requirement,
    string benefit,
    string location,
    int jobType,
    Decimal salary
) : IRequest<Result<JobCommandResponse>>;
