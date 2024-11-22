
using JobSite.Application.Common.Models;

namespace JobSite.Application.Application.Queries.GetListApplicationByResume;

public record GetListApplicationByResumeQuery
(
    Guid id
) : IRequest<Result<GetListApplicationByResumeResponse>>;