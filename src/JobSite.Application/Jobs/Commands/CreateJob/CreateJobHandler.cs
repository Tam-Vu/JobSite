

using JobSite.Application.Common.Exceptions;
using JobSite.Application.Common.Security.Identity;
using JobSite.Application.IRepository;
// using JobSite.Application.Jobs.Commands.CreateJob;
using Microsoft.AspNetCore.Http.HttpResults;

namespace JobSite.Application.Jobs.Commands.CreateJob;
public class CreateJobHandler : IRequestHandler<CreateJobCommand, JobResponseData>
{
    private readonly IJobRepository _jobRepository;
    private readonly IUser _user;
    private readonly IEmployeeRepository _employeeRepository;
    public CreateJobHandler(IJobRepository jobRepository, IUser user, IEmployeeRepository employeeRepository)
    {
        _jobRepository = jobRepository;
        _user = user;
        _employeeRepository = employeeRepository;
    }
    public async Task<JobResponseData> Handle(CreateJobCommand request, CancellationToken cancellationToken)
    {
        var employer = await _employeeRepository.GetOneAsync(x => x.AccountId.ToString() == _user.Id, cancellationToken);
        if (employer == null)
        {
            throw new NotFoundException("Employer not found");
        }
        var entity = new Job
        {
            Title = request.Title,
            Description = request.Description,
            Requirement = request.Requirement,
            Benefit = request.Benefit,
            Location = request.Location,
            Salary = request.Salary,
            JobType = (Domain.Enums.JobType)request.JobType,
            EmployerId = employer.Id,
        };
        try
        {
            await _jobRepository.AddAsync(entity, cancellationToken);
        }
        catch (Exception ex)
        {
            throw new BadRequestException(ex.Message);
        }
        return JobResponseData.Success(entity);
    }
}