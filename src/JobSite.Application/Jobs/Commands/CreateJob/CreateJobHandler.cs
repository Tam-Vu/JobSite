

using JobSite.Application.Common.Exceptions;
using JobSite.Application.IRepository;
// using JobSite.Application.Jobs.Commands.CreateJob;
using Microsoft.AspNetCore.Http.HttpResults;

namespace JobSite.Application.Jobs.Commands.CreateJob;
public class CreateJobHandler : IRequestHandler<CreateJobCommand, JobResponseData>
{
    private readonly IJobRepository _jobRepository;
    public CreateJobHandler(IJobRepository jobRepository)
    {
        _jobRepository = jobRepository;
    }
    public async Task<JobResponseData> Handle(CreateJobCommand request, CancellationToken cancellationToken)
    {
        var entity = new Job
        {
            Title = request.Title,
            Description = request.Description,
            Requirement = request.Requirement,
            Benefit = request.Benefit,
            Location = request.Location,
            Salary = request.Salary,
            JobType = (Domain.Enums.JobType)request.JobType,
            EmployerId = new Guid(),
        };
        await _jobRepository.AddAsync(entity, cancellationToken);
        return JobResponseData.Success(entity);
    }
}