
using System.Linq.Expressions;
using JobSite.Application.IRepository;
using JobSite.Application.Resumes.Common;
using JobSite.Domain.Common;
using Mapster;

namespace JobSite.Application.Resumes.Queries.GetResumeDetailsQuery;

public class GetResumeDetailsHandler : IRequestHandler<GetResumeDetailsQuery, ResponseResumeQuery>
{
    private readonly IResumeRepository _resumeRepository;
    public GetResumeDetailsHandler(IResumeRepository resumeRepository)
    {
        _resumeRepository = resumeRepository;
    }
    public async Task<ResponseResumeQuery> Handle(GetResumeDetailsQuery request, CancellationToken cancellationToken)
    {
        var resume = await _resumeRepository.GetByIdAsync(request.id,
            query => query.Include(x => x.Skills).Include(x => x.ExperienceDetails),
            cancellationToken);
        return resume.Adapt<ResponseResumeQuery>();
    }
}
