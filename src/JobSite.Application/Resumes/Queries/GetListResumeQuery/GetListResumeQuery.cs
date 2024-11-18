
using JobSite.Application.Resumes.Common;

namespace JobSite.Application.Resumes.Queries.GetListResumeQuery;
public record GetListResumeQuery : IRequest<List<ResponseResumeQuery>>;
