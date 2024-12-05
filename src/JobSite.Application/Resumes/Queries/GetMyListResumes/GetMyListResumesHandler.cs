using JobSite.Application.Common.Security.Identity;
using JobSite.Application.IRepository;
using JobSite.Application.Resumes.Common;
using MapsterMapper;

namespace JobSite.Application.Resumes.Queries.GetMyListResumes;

public class GetMyListResumesHandler : IRequestHandler<GetMyListResumesQuery, List<ResponseResumeQuery>>
{
    private readonly IUser _user;
    private readonly IMapper _mapper;
    private readonly IResumeRepository _resumeRepository;
    private readonly IEmployeeRepository _employeeRepository;

    public GetMyListResumesHandler(IUser user, IMapper mapper, IResumeRepository resumeRepository, IEmployeeRepository employeeRepository)
    {
        _user = user;
        _mapper = mapper;
        _resumeRepository = resumeRepository;
        _employeeRepository = employeeRepository;
    }

    public async Task<List<ResponseResumeQuery>> Handle(GetMyListResumesQuery request, CancellationToken cancellationToken)
    {
        var userId = _user.Id;
        var employee = await _employeeRepository.GetOneAsync(x => x.AccountId.ToString() == userId, cancellationToken);
        var resumes = await _resumeRepository.GetAllAsync(x => x.EmployeeId == employee.Id, cancellationToken);
        return _mapper.Map<List<ResponseResumeQuery>>(resumes);
    }
}