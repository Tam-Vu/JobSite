
using JobSite.Application.IRepository;
using JobSite.Application.Resumes.Common;
using Mapster;

namespace JobSite.Application.Resumes.Queries.GetListResumeQuery;
public class GetListResumeHandler : IRequestHandler<GetListResumeQuery, List<ResponseResumeQuery>>
{
    private readonly IResumeRepository _resumeRepository;
    public GetListResumeHandler(IResumeRepository resumeRepository)
    {
        _resumeRepository = resumeRepository;
    }


    public async Task<List<ResponseResumeQuery>> Handle(GetListResumeQuery request, CancellationToken cancellationToken)
    {
        var resumes = await _resumeRepository.GetAllAsync(query => query.Include(x => x.Skills).Include(x => x.ExperienceDetails), cancellationToken);
        return resumes.Adapt<List<ResponseResumeQuery>>();
    }
}