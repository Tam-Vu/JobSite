
using JobSite.Application.Common.Security.Request;
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
) : IRequest<JobResponseData>;
