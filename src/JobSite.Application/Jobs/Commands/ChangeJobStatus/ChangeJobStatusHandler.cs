using JobSite.Application.Common.Exceptions;
using JobSite.Application.Common.Models;
using JobSite.Application.Common.Security.Identity;
using JobSite.Application.IRepository;
using JobSite.Application.Jobs.Common;
using MapsterMapper;
using Microsoft.AspNetCore.Http;

namespace JobSite.Application.Jobs.Commands.ChangeJobStatus;

public class ChangeJobStatusHandler : IRequestHandler<ChangeJobStatusCommand, Result<JobCommandResponse>>
{
    private readonly IJobRepository _jobRepository;
    private readonly IUser _user;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;
    public ChangeJobStatusHandler(IJobRepository jobRepository, IUser user, IEmployeeRepository employeeRepository, IMapper mapper)
    {
        _jobRepository = jobRepository;
        _user = user;
        _employeeRepository = employeeRepository;
        _mapper = mapper;
    }
    public async Task<Result<JobCommandResponse>> Handle(ChangeJobStatusCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var employer = await _employeeRepository.GetOneAsync(x => x.AccountId.ToString() == _user.Id, cancellationToken);
            var job = await _jobRepository.GetOneAsync(x => x.Id == request.Id && x.EmployerId == employer.Id, cancellationToken);
            job.Status = (Domain.Enums.JobStatus)request.Status;
            await _jobRepository.UpdateAsync(job, cancellationToken);
            var response = _mapper.Map<JobCommandResponse>(job);
            return Result<JobCommandResponse>.Success(response);
        }
        catch (Exception e)
        {
            throw new BadRequestException(e.Message);
        }
    }
}
