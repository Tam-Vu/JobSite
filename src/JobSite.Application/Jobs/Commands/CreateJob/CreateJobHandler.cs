

using JobSite.Application.Common.Exceptions;
using JobSite.Application.Common.Models;
using JobSite.Application.Common.Security.Identity;
using JobSite.Application.IRepository;
using JobSite.Application.Jobs.Common;
using Microsoft.AspNetCore.Http.HttpResults;

namespace JobSite.Application.Jobs.Commands.CreateJob;
public class CreateJobHandler : IRequestHandler<CreateJobCommand, Result<JobCommandResponse>>
{
    private readonly IJobRepository _jobRepository;
    private readonly IUser _user;
    private readonly IEmployerRepository _employerRepository;
    public CreateJobHandler(IJobRepository jobRepository, IUser user, IEmployerRepository employerRepository)
    {
        _jobRepository = jobRepository;
        _user = user;
        _employerRepository = employerRepository;
    }
    public async Task<Result<JobCommandResponse>> Handle(CreateJobCommand request, CancellationToken cancellationToken)
    {
        var employer = await _employerRepository.GetOneAsync(x => x.AccountId.ToString() == _user.Id, cancellationToken);
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
        return Result<JobCommandResponse>.Success(new JobCommandResponse(entity.Id, entity.Created, entity.LastModified));
    }
}