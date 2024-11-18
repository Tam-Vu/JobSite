using JobSite.Application.Resumes.Common;

namespace JobSite.Application.Resumes.Queries.GetResumeDetailsQuery;

public record GetResumeDetailsQuery(
    Guid id
) : IRequest<ResponseResumeQuery>;
