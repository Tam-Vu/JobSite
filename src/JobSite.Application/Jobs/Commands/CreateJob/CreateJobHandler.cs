

using JobSite.Application.IRepository;
using JobSite.Application.Jobs.Commands.CreateJob;

namespace JobSite.Application.Jobs.Commands;
public class CreateJobHandler(IJobRepository _jobRepository) : IRequestHandler<CreateJobCommand, JobResponseData>
{
    public Task<JobResponseData> Handle(CreateJobCommand request, CancellationToken cancellationToken)
    {
        var entity = new Job
        {
            Title = request.Title,
            Description = request.Description,
            Location = request.Location,
            Salary = request.Salary,
            JobType = (Domain.Enums.JobType)request.JobType,
            EmployerId = request.EmployerId
        };
        _jobRepository.AddAsync(entity, cancellationToken);
        return Task.FromResult(JobResponseData.Success(entity));
    }
}