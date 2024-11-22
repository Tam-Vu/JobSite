using JobSite.Application.Application.Common;
using JobSite.Application.Common.Exceptions;
using JobSite.Application.Common.Models;
using JobSite.Application.IRepository;
using MapsterMapper;

namespace JobSite.Application.Application.Queries.GetListApplicationsByJob;

public class GetListApplicationsByJobHandler : IRequestHandler<GetListApplicationsByJobQuery, Result<List<ApplicationDto>>>
{
    private readonly IJobApplicationRepository _jobApplicationRepository;
    private readonly IMapper _mapper;
    public GetListApplicationsByJobHandler(IJobApplicationRepository jobApplicationRepository, IMapper mapper)
    {
        _jobApplicationRepository = jobApplicationRepository;
        _mapper = mapper;
    }
    public async Task<Result<List<ApplicationDto>>> Handle(GetListApplicationsByJobQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var applications = await _jobApplicationRepository.GetAllAsync(
                x => x.JobId == request.id,
                include => include.Include(y => y.Resume)
                                    .ThenInclude(y => y.Skills)
                                    .Include(y => y.Resume)
                                    .ThenInclude(y => y.ExperienceDetails)
                                    .Include(y => y.Resume)
                                    .ThenInclude(y => y.Employee)
                                    .ThenInclude(y => y.Account),
                cancellationToken);
            var result = applications.Select(x => _mapper.Map<ApplicationDto>(x)).ToList();
            return Result<List<ApplicationDto>>.Success(result);
        }
        catch (Exception e)
        {
            throw new BadRequestException(e.Message);
        }
    }
}
