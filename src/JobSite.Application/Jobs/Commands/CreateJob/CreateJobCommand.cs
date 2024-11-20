
using JobSite.Application.Common.Models;
using JobSite.Application.Jobs.Common;
using JobSite.Domain.Enums;

namespace JobSite.Application.Jobs.Commands.CreateJob;
public record CreateJobCommand
(
    string Title,
    string Description,
    string Requirement,
    string Benefit,
    string Location,
    JobType JobType,
    Decimal Salary
) : IRequest<Result<JobCommandResponse>>;
