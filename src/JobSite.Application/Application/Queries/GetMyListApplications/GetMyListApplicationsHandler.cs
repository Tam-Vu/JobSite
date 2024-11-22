using JobSite.Application.Common;
using JobSite.Application.Common.Exceptions;
using JobSite.Application.Common.Models;
using JobSite.Application.Common.Security.Identity;
using JobSite.Application.IRepository;
using MapsterMapper;

namespace JobSite.Application.Application.Queries.GetMyListApplications;

public class GetMyListApplicationsHandler : IRequestHandler<GetMyListApplicationsQuery, Result<List<JustApplicationDto>>>
{
    private readonly IMapper _mapper;
    private readonly IResumeRepository _resumeRepository;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IUser _user;
    private readonly IJobApplicationRepository _applicationRepository;
    public GetMyListApplicationsHandler(IResumeRepository resumeRepository, IEmployeeRepository employeeRepository, IMapper mapper, IUser user, IJobApplicationRepository applicationRepository)
    {
        _resumeRepository = resumeRepository;
        _employeeRepository = employeeRepository;
        _mapper = mapper;
        _user = user;
        _applicationRepository = applicationRepository;
    }
    public async Task<Result<List<JustApplicationDto>>> Handle(GetMyListApplicationsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var Employee = await _employeeRepository.GetOneAsync(x => x.AccountId.ToString() == _user.Id, cancellationToken);
            var resume = await _resumeRepository.GetOneAsync(x => x.EmployeeId == Employee.Id, cancellationToken);
            var applications = await _applicationRepository.GetAllAsync(
                x => x.ResumeId == resume.Id,
                include => include
                    .Include(y => y.Resume)
                    .Include(y => y.Job)
                    .ThenInclude(y => y.Employer),
                cancellationToken
            );
            var result = applications.Select(x => _mapper.Map<JustApplicationDto>(x)).ToList();
            return Result<List<JustApplicationDto>>.Success(result);
        }
        catch (Exception e)
        {
            throw new BadRequestException(e.Message);
        }

    }
}
