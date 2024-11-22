using JobSite.Application.Common.Exceptions;
using JobSite.Application.Common.Models;
using JobSite.Application.IRepository;
using MapsterMapper;

namespace JobSite.Application.Application.Queries.GetListApplicationByResume;

public class GetListApplicationByResumeHandler : IRequestHandler<GetListApplicationByResumeQuery, Result<GetListApplicationByResumeResponse>>
{
    private readonly IMapper _mapper;
    private readonly IResumeRepository _resumeRepository;
    public GetListApplicationByResumeHandler(IResumeRepository resumeRepository, IMapper mapper)
    {
        _resumeRepository = resumeRepository;
        _mapper = mapper;
    }
    public async Task<Result<GetListApplicationByResumeResponse>> Handle(GetListApplicationByResumeQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var applications = await _resumeRepository.GetByIdAsync(
                request.id,
                include => include
                    .Include(y => y.Applications)
                    .ThenInclude(y => y.Job)
                    .ThenInclude(y => y.Employer),
                cancellationToken
            );
            var result = _mapper.Map<GetListApplicationByResumeResponse>(applications);
            return Result<GetListApplicationByResumeResponse>.Success(result);
        }
        catch (Exception e)
        {
            throw new BadRequestException(e.Message);
        }
    }
}