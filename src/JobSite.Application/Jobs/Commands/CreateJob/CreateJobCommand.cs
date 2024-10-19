
using JobSite.Application.Common.Security.Request;

namespace JobSite.Application.Jobs.Commands.CreateJob;
public record CreateJobCommand
(
    string Title,
    string Description,
    string Location,
    int JobType,
    Decimal Salary,
    Guid EmployerId
) : IRequest<JobResponseData>;
